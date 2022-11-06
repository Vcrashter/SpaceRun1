using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;

    private bool isJumping = false;
    private bool isTouching = false;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        if (isTouching == false)
        {
            transform.Translate(_xValue * Time.deltaTime * _moveSpeed, 0f, _zValue * Time.deltaTime * _moveSpeed);
        }

        else
        {
            transform.Translate(0f, 0f, 0f);
        }
    }

    private void Jump()
    {
        if(isJumping == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
                isJumping = true;
                isTouching = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject)
        {
            isJumping = false;
            isTouching = true;
        }
    }
}
