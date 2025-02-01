using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    private int currentHealth;

    // Используем Awake для инициализации, чтобы гарантировать, что здоровье установлено один раз.
    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    // Реализация контракта IDamageable
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} получил {damage} урона. Текущее здоровье: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Единственная ответственность — обработка смерти объекта
    private void Die()
    {
        Debug.Log($"{gameObject.name} умер!");
        Destroy(gameObject);
    }
}
