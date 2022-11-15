using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlatform : MonoBehaviour
{
    [SerializeField] float _cyrcleLength = 1f;

    private void Start()
    {
        Movement();
    }

    private void Movement()
    {
        gameObject.transform.DOMoveZ(gameObject.transform.position.z + 10f, _cyrcleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
