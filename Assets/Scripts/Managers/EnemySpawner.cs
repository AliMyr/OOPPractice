using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyController enemyPrefab; // ������ �����, � �������� ������ ���� EnemyController, Movement � Health
    public int initialPoolSize = 10;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;

    private ObjectPool<EnemyController> enemyPool;
    private float spawnTimer = 0f;

    private void Start()
    {
        // ������� ��� ������; � �������� �������� ����� �������� ���� ������, ����� �� ���� ������������
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
        // �������� ����� �� ����
        EnemyController enemy = enemyPool.GetObject();

        // ��������� ��������� ��������� �� ����� ������ ��������
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        enemy.transform.position = new Vector3(transform.position.x + randomCircle.x, transform.position.y, transform.position.z + randomCircle.y);

        // ��� ������������� ����� �������� ��������� ����� (��������, ��������, ��������� � �.�.)

        // ������������� �� ������� ������, ����� ������� ����� � ��� ����� ��� �����������
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            // ������� ������������, ����� �� ����������� ������ �������� (�� ������ ���������� �������������)
            enemyHealth.OnDied -= () => { enemyPool.ReturnObject(enemy); };
            enemyHealth.OnDied += () => { enemyPool.ReturnObject(enemy); };
        }
    }
}
