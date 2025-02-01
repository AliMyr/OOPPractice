using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ������ �� Game Over ������ (������ � � Canvas � ������� ����� Inspector)
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
            Debug.LogError("GameOverPanel �� ��������� � UIManager!");
        }
    }

    // �����, ������� ����� ��������� � ������ "Restart" � UI
    public void RestartGame()
    {
        Time.timeScale = 1f;  // ���������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
