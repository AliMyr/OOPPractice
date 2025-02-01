using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // —сылка на Game Over панель (создай еЄ в Canvas и назначь через Inspector)
    public GameObject gameOverPanel;

    private void OnEnable()
    {
        GameEvents.OnGameOver += ShowGameOverPanel;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverPanel;
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverPanel не назначена в UIManager!");
        }
    }

    // ћетод, который можно прив€зать к кнопке "Restart" в UI
    public void RestartGame()
    {
        Time.timeScale = 1f;  // —брасываем паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
