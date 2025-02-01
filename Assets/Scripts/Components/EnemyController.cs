using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMovable movable;
    private IDamageable damageable;
    public Transform target;
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;
    private float attackTimer = 0f;

    private void Awake()
    {
        movable = GetComponent<IMovable>();
        if (movable == null)
            Debug.LogError("Enemy " + gameObject.name + " �� ����� ����������, ������������ IMovable!");

        damageable = GetComponent<IDamageable>();
        if (damageable == null)
            Debug.LogError("Enemy " + gameObject.name + " �� ����� ����������, ������������ IDamageable!");

        // ������������� �� ������� ������, ���� ���� ��������� Health
        var health = GetComponent<Health>();
        if (health != null)
        {
            health.OnDied += () => { GameEvents.EnemyKilled(); };
        }
    }

    private void Update()
    {
        // ���� ���� �� ������, ������� ����� ������ �� ���� "Player"
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                target = playerObj.transform;
            }
            else
            {
                return;
            }
        }

        // ��������� � ������� ������
        Vector3 direction = (target.position - transform.position).normalized;
        movable.Move(direction);

        // �������� ���������, ���� � �������� ������������
        attackTimer += Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer >= attackCooldown)
        {
            IDamageable targetDamageable = target.GetComponent<IDamageable>();
            if (targetDamageable != null)
            {
                targetDamageable.TakeDamage(attackDamage);
                attackTimer = 0f;
            }
        }
    }
}
