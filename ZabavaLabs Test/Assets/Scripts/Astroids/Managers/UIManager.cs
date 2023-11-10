using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    
    private void Start()
    {
        GameManager.instance.OnGameOver += OnGameOver;
        GameManager.instance.OnGameWin += OnGameWin;   
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameWin -= OnGameWin;
        GameManager.instance.OnGameOver -= OnGameOver;
    }

    private void OnGameWin()
    {
        winPanel.SetActive(true);
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}