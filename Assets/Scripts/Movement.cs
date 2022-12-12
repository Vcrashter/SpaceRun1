using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed =8f;
    [SerializeField] int _life = 3;

    private bool isJumping = false;

    [SerializeField] private Button _jumpButton;

    private Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] FixedJoystick _joystick;
    private GameMaster gm;

    private void Start()
    {
        if (_jumpButton != null)
        {
            _jumpButton.onClick.AddListener(Jump);
        }
        rb = GetComponent<Rigidbody>();
        UIManager.Instance.UpdateLife(Life());
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
        anim = gameObject.GetComponentInChildren<Animator>();
        transform.position = new Vector3(0f, 1.67f, 0f);
    }
    private void FixedUpdate()
    {
        MovementProcess();
    }

    private void PlayAnimation(bool isPlayingAnim)
    {
        if (isPlayingAnim)
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
    }

    private void MovementProcess()
    {
#if UNITY_EDITOR
        float _xValue = Input.GetAxis("Horizontal");
        float _zValue = Input.GetAxis("Vertical");
        transform.Translate(_xValue * Time.deltaTime * _moveSpeed, 0f, _zValue * Time.deltaTime * _moveSpeed);
#endif
        if (_joystick.Horizontal != 0f)
        {
            PlayAnimation(true);
        }
        
        else
        {
            PlayAnimation(false);
        }

        transform.Translate(_joystick.Horizontal * _moveSpeed * Time.deltaTime, 0f, _joystick.Vertical * _moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (!isJumping)
        {
            rb.velocity = Vector3.up * 20f;
            transform.parent = null;
            isJumping = true;
        }

        if(isJumping)
        {
            rb.velocity += Vector3.up * Physics.gravity.y;
            PlayAnimation(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("FinishMenu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            gameObject.transform.position = gm.lastCheckPointPos;
            _life--;
            transform.parent = null;
        }

        UIManager.Instance.UpdateLife(Life());

        if (_life == 0f)
        {
            SceneManager.LoadScene("loseMenu");
        }
    }

    public int Life()
    {
        return _life;
    }
}