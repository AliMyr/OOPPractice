using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Ссылка на UI-элемент, который отображает счёт (например, Text)
    public Text scoreText;

    private int score = 0;

    private void OnEnable()
    {
        // Подписываемся на глобальное событие
        GameEvents.OnEnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        // Отписываемся, чтобы избежать утечек памяти
        GameEvents.OnEnemyKilled -= AddScore;
    }

    // Метод, вызываемый при убийстве врага
    private void AddScore()
    {
        score += 100; // Например, за каждого врага даём 100 очков
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
