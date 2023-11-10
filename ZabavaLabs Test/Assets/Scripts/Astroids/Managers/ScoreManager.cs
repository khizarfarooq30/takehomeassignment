using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private int scoreToAdd;

    private int score;

    private void Start()
    {
        GameManager.instance.OnShootObstacle += AddScore;
    }

    private void OnDisable()
    {
        GameManager.instance.OnShootObstacle -= AddScore;
    }

    public void AddScore()
    {
        // each time score will be incremented by 1 + scoreToAdd assigned in inspector
        score += scoreToAdd;
        score++;
        scoreText.SetText(score.ToString("0000000"));
    }
    
    public void ResetScore()
    {
        score = 0;
    }
}