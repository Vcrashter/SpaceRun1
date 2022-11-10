using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _coinPoints;

    public GameObject player;

    private void Update()
    {
        transform.Rotate(0, 0, 2.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            _coinPoints = 3f;
            Destroy(gameObject);
        }
    }

    public float GetCoin()
    {
        return _coinPoints;
    }
}
