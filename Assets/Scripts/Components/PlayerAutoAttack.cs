using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour, IAttacker
{
    [Header("Auto Attack Settings")]
    [Tooltip("Радиус, в пределах которого игрок будет искать врагов для автоатаки.")]
    public float attackRange = 5f;
    [Tooltip("Время между атаками (в секундах).")]
    public float attackCooldown = 1.0f;
    [Tooltip("Количество урона, наносимого за одну атаку.")]
    public int attackDamage = 20;
    [Tooltip("Слой, на котором находятся враги.")]
    public LayerMask enemyLayer;

    private float attackTimer = 0f;

    /// <summary>
    /// Реализация метода атаки по цели.
    /// </summary>
    /// <param name="target">Цель, реализующая IDamageable.</param>
    public void Attack(IDamageable target)
    {
        if (target != null)
        {
            target.TakeDamage(attackDamage);
            // Здесь можно добавить вызов анимаций, звуков или эффектов.
            Debug.Log($"{gameObject.name} атакует цель, нанося {attackDamage} урона.");
        }
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            // Находим все объекты-врагов в пределах attackRange на заданном слое.
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
            if (hitColliders.Length > 0)
            {
                // Для простоты возьмём первого найденного врага. Можно добавить выбор ближайшего, если надо.
                IDamageable enemyDamageable = hitColliders[0].GetComponent<IDamageable>();
                if (enemyDamageable != null)
                {
                    Attack(enemyDamageable);
                    attackTimer = 0f; // Сбрасываем таймер после атаки.
                }
            }
        }
    }

    // Для визуализации радиуса атаки в редакторе.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
