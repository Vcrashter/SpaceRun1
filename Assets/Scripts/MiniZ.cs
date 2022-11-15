using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniZ : MonoBehaviour
{
    [SerializeField] float _platformPointsZ;

    private bool _isPointed = false;

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
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
