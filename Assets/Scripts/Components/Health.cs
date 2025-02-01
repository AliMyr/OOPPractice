using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    private int currentHealth;

    // ���������� Awake ��� �������������, ����� �������������, ��� �������� ����������� ���� ���.
    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    // ���������� ��������� IDamageable
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} ������� {damage} �����. ������� ��������: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ������������ ��������������� � ��������� ������ �������
    private void Die()
    {
        Debug.Log($"{gameObject.name} ����!");
        Destroy(gameObject);
    }
}
