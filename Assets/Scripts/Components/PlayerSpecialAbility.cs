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
    [Tooltip("��������� ��������� ����������� � �������.")]
    public float staminaCost = 30f;

    // ������ ��� ������������ ��������
    private float abilityTimer = 0f;
    private Stamina stamina;

    private void Awake()
    {
        // �������� �������� ��������� ������� � ������
        stamina = GetComponent<Stamina>();
        if (stamina == null)
            Debug.LogWarning($"{gameObject.name}: ������� �� �������! ����������� �� ������ ����������� �������.");
    }

    private void Update()
    {
        // ��������� ������ ��������
        abilityTimer += Time.deltaTime;

        // ���� ������ ������� (��������, ������) � ������� ����
        if (Input.GetKeyDown(KeyCode.Space) && abilityTimer >= abilityCooldown)
        {
            // ���������, ���������� �� �������
            if (stamina != null && stamina.ConsumeStamina(staminaCost))
            {
                Activate();
            }
            else
            {
                Debug.Log("������������ ������� ��� ��������� ����������� �����������!");
            }
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

    /// <summary>
    /// ��������� ��������� ���� �����������.
    /// </summary>
    public void IncreaseDamage(int additionalDamage)
    {
        abilityDamage += additionalDamage;
        Debug.Log($"{gameObject.name}: ����������� ����������� ��������. ����� ����: {abilityDamage}");
    }

    /// <summary>
    /// ��������� ��������� ������� �����������.
    /// </summary>
    public void ReduceCooldown(float reduction)
    {
        abilityCooldown = Mathf.Max(0.1f, abilityCooldown - reduction);
        Debug.Log($"{gameObject.name}: ������� ����������� ����������� ��������. ����� �������: {abilityCooldown}");
    }

    /// <summary>
    /// ���������� �������� �������� (�� 0 �� 1).
    /// </summary>
    public float GetCooldownProgress()
    {
        return Mathf.Clamp01(abilityTimer / abilityCooldown);
    }

    // ��� ������������ ������� �������� � ���������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, abilityRadius);
    }
}
