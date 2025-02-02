using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour, IAttacker
{
    [Header("Auto Attack Settings")]
    [Tooltip("������, � �������� �������� ����� ����� ������ ������ ��� ���������.")]
    public float attackRange = 5f;
    [Tooltip("����� ����� ������� (� ��������).")]
    public float attackCooldown = 1.0f;
    [Tooltip("���������� �����, ���������� �� ���� �����.")]
    public int attackDamage = 20;
    [Tooltip("����, �� ������� ��������� �����.")]
    public LayerMask enemyLayer;

    private float attackTimer = 0f;

    /// <summary>
    /// ���������� ������ ����� �� ����.
    /// </summary>
    /// <param name="target">����, ����������� IDamageable.</param>
    public void Attack(IDamageable target)
    {
        if (target != null)
        {
            target.TakeDamage(attackDamage);
            // ����� ����� �������� ����� ��������, ������ ��� ��������.
            Debug.Log($"{gameObject.name} ������� ����, ������ {attackDamage} �����.");
        }
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            // ������� ��� �������-������ � �������� attackRange �� �������� ����.
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
            if (hitColliders.Length > 0)
            {
                // ��� �������� ������ ������� ���������� �����. ����� �������� ����� ����������, ���� ����.
                IDamageable enemyDamageable = hitColliders[0].GetComponent<IDamageable>();
                if (enemyDamageable != null)
                {
                    Attack(enemyDamageable);
                    attackTimer = 0f; // ���������� ������ ����� �����.
                }
            }
        }
    }

    // ��� ������������ ������� ����� � ���������.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
