using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncreamentScore(int increament)
    {
        score += increament;
        RefreshUI();
    }

    void RefreshUI()
    {
        scoreText.text = "" + score;
    }
}
