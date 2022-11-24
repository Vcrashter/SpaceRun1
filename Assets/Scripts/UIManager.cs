using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private float _points;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateLife(int Life)
    {
        lifeText.text = " " + Life;
    }

    public void UpdateScore(float GetCoin)
    {
        _points += GetCoin;
        scoreText.text = " " + _points;
    }
}
