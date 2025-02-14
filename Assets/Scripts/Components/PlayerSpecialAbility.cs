using UnityEngine;

public class PlayerSpecialAbility : MonoBehaviour, ISpecialAbility
{
    [Header("Special Ability Settings")]
    [Tooltip("������ �������� ����������� �����������.")]
    public float abilityRadius = 7f;
    [Tooltip("����, ��������� ����������� ������������.")]
    public int abilityDamage = 50;
    [Tooltip("����� ����������� ����������� (� ��������).")]
    public float abilityCooldown = 10f;
    [Tooltip("����, �� ������� ��������� �����.")]
    public LayerMask enemyLayer;

    // ������ ��� ������������ ��������
    private float abilityTimer = 0f;

    private void Update()
    {
        // ��������� ������ ��������
        abilityTimer += Time.deltaTime;

        // ���� ������ ������� (��������, ������) � ������� ����, ���������� �����������
        if (Input.GetKeyDown(KeyCode.Space) && abilityTimer >= abilityCooldown)
        {
            Activate();
        }
    }

    /// <summary>
    /// ���������� ����������� �����������: ���� ������ � ������� � ������� �� ����.
    /// </summary>
    public void Activate()
    {
        // ���������� ������ ��������
        abilityTimer = 0f;

        // ���� ��� ���������� ������ � �������� abilityRadius �� �������� ����
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

        Debug.Log($"{gameObject.name} ����������� ����������� �����������, ������ {abilityDamage} ����� {affectedEnemies} ������.");
        // ����� ����� �������� ����� ��������, �������� �������� � ���������� ��������.
    }

    public void IncreaseDamage(int additionalDamage)
    {
        abilityDamage += additionalDamage;
        Debug.Log($"{gameObject.name}: ����������� ����������� ��������. ����� ����: {abilityDamage}");
    }

    // ����� �������� ����� ��� ���������� ��������, ���� �����:
    public void ReduceCooldown(float reduction)
    {
        abilityCooldown = Mathf.Max(0.1f, abilityCooldown - reduction);
        Debug.Log($"{gameObject.name}: ������� ����������� ����������� ��������. ����� �������: {abilityCooldown}");
    }


    // ��� ������������ ������� �������� � ���������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, abilityRadius);
    }

}
