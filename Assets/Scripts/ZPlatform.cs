using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlatform : MonoBehaviour
{
    [SerializeField] float _cyrcleLength = 3f;

    private float frontPos;

    public GameObject player;

    private void Start()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void Move()
    {
        gameObject.transform.DOMoveZ(gameObject.transform.position.z + 10f, _cyrcleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
