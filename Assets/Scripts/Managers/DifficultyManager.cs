using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Header("Difficulty Settings")]
    public float difficultyIncreaseInterval = 30f; // ��������, ����� ������� ��������� ���������� (� ��������)
    public float spawnIntervalDecrease = 0.5f;       // �� ������� ����������� �������� ������
    public float minimumSpawnInterval = 0.5f;          // ���������� ���������� �������� ������

    private float timer = 0f;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        // �������� ����� EnemySpawner � �����
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("DifficultyManager: EnemySpawner �� ������!");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= difficultyIncreaseInterval)
        {
            timer = 0f;
            IncreaseDifficulty();
        }
    }

    private void IncreaseDifficulty()
    {
        if (enemySpawner != null)
        {
            // ��������� �������� ������, �� �� ���� ��������
            enemySpawner.spawnInterval = Mathf.Max(minimumSpawnInterval, enemySpawner.spawnInterval - spawnIntervalDecrease);
            Debug.Log("��������� ���������! ����� �������� ������: " + enemySpawner.spawnInterval);
        }
    }
}
