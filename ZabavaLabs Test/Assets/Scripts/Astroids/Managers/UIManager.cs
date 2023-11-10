using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    
    private void Start()
    {
        GameManager.instance.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}