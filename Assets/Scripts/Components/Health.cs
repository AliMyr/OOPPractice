using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    private int currentHealth;

    // Событие, которое сигнализирует об изменении здоровья
    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = MaxHealth;
        // Немного багфикс: сразу уведомляем о начальном значении
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} получил {damage} урона. Текущее здоровье: {currentHealth}");
        // Сообщаем об изменении здоровья
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} умер!");
        Destroy(gameObject);
    }
}
