using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] int _life = 3;

    private bool isJumping = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UIManager.Instance.UpdateLife(Life());
    }
    void Update()
    {
        Jump();
        MovementProcess();
    }

    private void MovementProcess()
    {
        float _xValue = Input.GetAxis("Horizontal");
        float _zValue = Input.GetAxis("Vertical");
        transform.Translate(_xValue * Time.deltaTime * _moveSpeed, 0f, _zValue * Time.deltaTime * _moveSpeed);
    }

    private void Jump()
    {
        if (isJumping == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0f, 15f, 0f), ForceMode.Impulse);
                transform.parent = null;
                isJumping = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Check3")
        {
            if (other.gameObject.tag == "Destroyer")
            {
                gameObject.transform.position = new Vector3(1f, 1.67f, 255f);
                _life--;
                transform.parent = null;
            }
        }

        else if (other.gameObject.tag == "Check2")
        {
            if (other.gameObject.tag == "Destroyer")
            {
                gameObject.transform.position = new Vector3(1f, 1.67f, 177f);
                _life--;
                transform.parent = null;
            }
        }

        else if (other.gameObject.tag == "Check1")
        {
            if (other.gameObject.tag == "Destroyer")
            {
                gameObject.transform.position = new Vector3(11f, 1.67f, 78f);
                _life--;
                transform.parent = null;
            }
        }
        else
        {
            if (other.gameObject.tag == "Destroyer")
            {
                gameObject.transform.position = new Vector3(0f, 1.67f, 0f);
                _life--;
                transform.parent = null;
            }
        }
        UIManager.Instance.UpdateLife(Life());

        if (_life == 0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public int Life()
    {
        return _life;
    }
}