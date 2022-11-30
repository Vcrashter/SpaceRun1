using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _coinPoints;

    private void Start()
    {
        UIManager.Instance.UpdateScore(GetCoin());
    }
    private void Update()
    {
        transform.Rotate(0, 0, 2.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _coinPoints = 3f;
            Destroy(gameObject);
            transform.Rotate(0, 0, 0);
        }

        UIManager.Instance.UpdateScore(GetCoin());
    }

    public float GetCoin()
    {
        return _coinPoints;
    }
}
