using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyController enemyPrefab; // Префаб врага, у которого должен быть EnemyController, Movement и Health
    public int initialPoolSize = 10;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;

    private ObjectPool<EnemyController> enemyPool;
    private float spawnTimer = 0f;

    private void Start()
    {
        // Создаем пул врагов; в качестве родителя можно передать этот объект, чтобы всё было организовано
        enemyPool = new ObjectPool<EnemyController>(enemyPrefab, initialPoolSize, transform);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        // Получаем врага из пула
        EnemyController enemy = enemyPool.GetObject();

        // Вычисляем случайное положение на круге вокруг спаунера
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        enemy.transform.position = new Vector3(transform.position.x + randomCircle.x, transform.position.y, transform.position.z + randomCircle.y);

        // При необходимости можно сбросить состояние врага (например, здоровье, поведение и т.д.)

        // Подписываемся на событие смерти, чтобы вернуть врага в пул после его уничтожения
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            // Сначала отписываемся, чтобы не накапливать лишние делегаты (на случай повторного использования)
            enemyHealth.OnDied -= () => { enemyPool.ReturnObject(enemy); };
            enemyHealth.OnDied += () => { enemyPool.ReturnObject(enemy); };
        }
    }
}
