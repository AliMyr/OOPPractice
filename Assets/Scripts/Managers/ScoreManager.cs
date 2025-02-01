using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ������ �� UI-�������, ������� ���������� ���� (��������, Text)
    public Text scoreText;

    private int score = 0;

    private void OnEnable()
    {
        // ������������� �� ���������� �������
        GameEvents.OnEnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        // ������������, ����� �������� ������ ������
        GameEvents.OnEnemyKilled -= AddScore;
    }

    // �����, ���������� ��� �������� �����
    private void AddScore()
    {
        score += 100; // ��������, �� ������� ����� ��� 100 �����
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
