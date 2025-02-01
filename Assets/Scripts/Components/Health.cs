using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    private int currentHealth;

    // �������, ������� ������������� �� ��������� ��������
    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = MaxHealth;
        // ������� �������: ����� ���������� � ��������� ��������
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} ������� {damage} �����. ������� ��������: {currentHealth}");
        // �������� �� ��������� ��������
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} ����!");
        Destroy(gameObject);
    }
}
