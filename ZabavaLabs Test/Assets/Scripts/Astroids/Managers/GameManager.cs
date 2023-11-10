using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action OnShootObstacle;
    public Action OnGameOver;
    public Action OnGameWin;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
    }

    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ShootObstacle()
    {
        OnShootObstacle?.Invoke();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
    
    public void GameWin()
    {
        OnGameWin?.Invoke();
    }
}