using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlatform : MonoBehaviour
{
    [SerializeField] float _platformPointsZ;
    [SerializeField] float _cyrcleLength = 1f;

    private bool _isPointed = false;

    public GameObject player;

    private void Start()
    {
        Movement();
    }

    private void Movement()
    {
        gameObject.transform.DOMoveZ(gameObject.transform.position.z + 10f, _cyrcleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = transform;
            if (_isPointed == false)
            {
                _platformPointsZ += 5f;
                _isPointed = true;
            }
        }
    }

    public float GetPoints()
    {
        return _platformPointsZ;
    }
}
