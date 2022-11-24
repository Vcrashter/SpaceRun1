using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlatform : MonoBehaviour
{
    [SerializeField] float _cyrcleLength = 1f;

    private float frontPos;

    public GameObject player;

    private void Start()
    {
        Move();
    }

    private void Update()
    {
        MoveContinue();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NullParenting();
        }
    }

    private void Move()
    {
        frontPos = gameObject.transform.position.z + 10f;
        gameObject.transform.DOMoveZ(frontPos, _cyrcleLength).OnComplete(NullParenting);
    }

    private void MoveContinue()
    {
        if (gameObject.transform.position.z == frontPos)
        {
            gameObject.transform.DOMoveZ(frontPos - 10f, _cyrcleLength).OnComplete(NullParenting);
        }

        if (gameObject.transform.position.z == frontPos - 10f)
        {
            gameObject.transform.DOMoveZ(frontPos, _cyrcleLength).OnComplete(NullParenting);
        }
    }


    private void NullParenting()
    {
        player.transform.parent = null;
    }
}
