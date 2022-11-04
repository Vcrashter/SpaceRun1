using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPlatform : MonoBehaviour
{
    [SerializeField] float _points;
    [SerializeField] float _platformPoints = 5f;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            _points += _platformPoints;
            Destroy(gameObject);
        }
    }
    public float Points(float _points)
    {
        return _points;
    }
}
