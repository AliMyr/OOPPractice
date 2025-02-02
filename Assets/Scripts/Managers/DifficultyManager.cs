using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Header("Difficulty Settings")]
    public float difficultyIncreaseInterval = 30f; // Интервал, через который сложность повышается (в секундах)
    public float spawnIntervalDecrease = 0.5f;       // На сколько уменьшается интервал спауна
    public float minimumSpawnInterval = 0.5f;          // Минимально допустимый интервал спауна

    private float timer = 0f;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        // Пытаемся найти EnemySpawner в сцене
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("DifficultyManager: EnemySpawner не найден!");
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
            // Уменьшаем интервал спауна, но не ниже минимума
            enemySpawner.spawnInterval = Mathf.Max(minimumSpawnInterval, enemySpawner.spawnInterval - spawnIntervalDecrease);
            Debug.Log("Сложность увеличена! Новый интервал спауна: " + enemySpawner.spawnInterval);
        }
    }
}
