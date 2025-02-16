using UnityEngine;

public class PlayerSpecialAbility : MonoBehaviour, ISpecialAbility
{
    [Header("Special Ability Settings")]
    [Tooltip("Радиус действия специальной способности.")]
    public float abilityRadius = 7f;
    [Tooltip("Урон, наносимый специальной способностью.")]
    public int abilityDamage = 50;
    [Tooltip("Время перезарядки способности (в секундах).")]
    public float abilityCooldown = 10f;
    [Tooltip("Слой, на котором находятся враги.")]
    public LayerMask enemyLayer;
    [Tooltip("Стоимость активации способности в стамине.")]
    public float staminaCost = 30f;

    // Таймер для отслеживания кулдауна
    private float abilityTimer = 0f;
    private Stamina stamina;

    private void Awake()
    {
        // Пытаемся получить компонент стамины с игрока
        stamina = GetComponent<Stamina>();
        if (stamina == null)
            Debug.LogWarning($"{gameObject.name}: Стамина не найдена! Способность не сможет расходовать стамину.");
    }

    private void Update()
    {
        // Обновляем таймер кулдауна
        abilityTimer += Time.deltaTime;

        // Если нажата клавиша (например, пробел) и кулдаун истёк
        if (Input.GetKeyDown(KeyCode.Space) && abilityTimer >= abilityCooldown)
        {
            // Проверяем, достаточно ли стамины
            if (stamina != null && stamina.ConsumeStamina(staminaCost))
            {
                Activate();
            }
            else
            {
                Debug.Log("Недостаточно стамины для активации специальной способности!");
            }
        }
    }

    /// <summary>
    /// Активирует специальную способность: ищет врагов в радиусе и наносит им урон.
    /// </summary>
    public void Activate()
    {
        // Сбрасываем таймер кулдауна
        abilityTimer = 0f;

        // Ищем все коллайдеры врагов в пределах abilityRadius на заданном слое
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, abilityRadius, enemyLayer);
        int affectedEnemies = 0;
        foreach (Collider collider in hitColliders)
        {
            IDamageable enemyDamageable = collider.GetComponent<IDamageable>();
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(abilityDamage);
                affectedEnemies++;
            }
        }

        Debug.Log($"{gameObject.name} активировал специальную способность, нанеся {abilityDamage} урона {affectedEnemies} врагам.");
        // Здесь можно добавить вызов анимаций, звуковых эффектов и визуальных эффектов.
    }

    /// <summary>
    /// Позволяет увеличить урон способности.
    /// </summary>
    public void IncreaseDamage(int additionalDamage)
    {
        abilityDamage += additionalDamage;
        Debug.Log($"{gameObject.name}: специальная способность улучшена. Новый урон: {abilityDamage}");
    }

    /// <summary>
    /// Позволяет уменьшить кулдаун способности.
    /// </summary>
    public void ReduceCooldown(float reduction)
    {
        abilityCooldown = Mathf.Max(0.1f, abilityCooldown - reduction);
        Debug.Log($"{gameObject.name}: кулдаун специальной способности уменьшен. Новый кулдаун: {abilityCooldown}");
    }

    /// <summary>
    /// Возвращает прогресс кулдауна (от 0 до 1).
    /// </summary>
    public float GetCooldownProgress()
    {
        return Mathf.Clamp01(abilityTimer / abilityCooldown);
    }

    // Для визуализации радиуса действия в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, abilityRadius);
    }
}
