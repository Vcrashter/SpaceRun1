using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPlatform : MonoBehaviour
{
    [SerializeField] float _points;
    [SerializeField] float _platformPoints = 5f;
    [SerializeField] float _cyrcleLength = 1f;

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
        if(collision.gameObject == player)
        {
            _points += _platformPoints;
            Destroy(gameObject);
            gameObject.transform.DOKill(true);
        }
    }
    public float Points(float _points)
    {
        return _points;
    }
}
