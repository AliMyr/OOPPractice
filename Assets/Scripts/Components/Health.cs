using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    private int currentHealth;

    // —обытие, оповещающее об изменении здоровь€
    public event Action<int> OnHealthChanged;
    // —обытие, оповещающее о смерти
    public event Action OnDied;

    private void Awake()
    {
        currentHealth = MaxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} получил {damage} урона. “екущее здоровье: {currentHealth}");
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} умер!");
        OnDied?.Invoke();
        Destroy(gameObject);
    }
}
