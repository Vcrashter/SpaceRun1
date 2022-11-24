using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPlatform : MonoBehaviour
{
    [SerializeField] float _cyrcleLength = 3f;

    private void Start()
    {
        Movement();
    }

    private void Movement()
    {
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 10f, _cyrcleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           collision.transform.parent = transform;
        }
    }
}
