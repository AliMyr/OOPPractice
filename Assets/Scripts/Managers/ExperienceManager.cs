using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience Settings")]
    // ���������� �����, ������� ����� �������� �� �������� �����
    public int experiencePerEnemy = 50;
    // ������ �� ��������� �������� ������ (����������� ����� Inspector)
    public PlayerProgression playerProgression;

    private void OnEnable()
    {
        // ������������� �� ���������� ������� �������� �����
        GameEvents.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        if (playerProgression != null)
        {
            Debug.Log("Enemy killed! ��������� ���� ������.");
            playerProgression.AddExperience(experiencePerEnemy);
        }
        else
        {
            Debug.LogWarning("ExperienceManager: ������ �� PlayerProgression �� ���������!");
        }
    }
}
