using UnityEngine;

public class AbilityUpgradeManager : MonoBehaviour
{
    // ���������� ��������� �������-�������
    public int UpgradePoints { get; private set; } = 0;

    // ������ �� ���������� ������������, ������� ����� �������� (����������� ����� Inspector)
    public PlayerAutoAttack playerAutoAttack;
    public PlayerSpecialAbility playerSpecialAbility;

    // ������������� �� ������� ��������� ������ ������
    // ������������, ��� ��������� PlayerProgression ��� ���� � ������
    public void Initialize(PlayerProgression progression)
    {
        if (progression != null)
        {
            progression.OnLevelUp += OnPlayerLevelUp;
        }
        else
        {
            Debug.LogError("AbilityUpgradeManager: PlayerProgression �� ��������!");
        }
    }

    // ���������� ��� ��������� ������ ������ � ��������� ���� �������-�����
    private void OnPlayerLevelUp(int newLevel)
    {
        UpgradePoints++;
        Debug.Log($"������� �������-�����! ����� ������: {UpgradePoints}");
        // ����� ����� ��������� UI � ������� ����� �������
    }

    // ����� ��� ��������� ���������: ����������� ���� �� �������� ��������
    public bool UpgradeAutoAttackDamage(int additionalDamage)
    {
        if (UpgradePoints > 0 && playerAutoAttack != null)
        {
            UpgradePoints--;
            playerAutoAttack.IncreaseDamage(additionalDamage);
            Debug.Log($"������� ��������� �������. �������� �������: {UpgradePoints}");
            return true;
        }
        Debug.LogWarning("�� ������� ������� ��� playerAutoAttack �� ��������!");
        return false;
    }

    // ����� ��� ��������� ����������� �����������: ����������� ���� �� �������� ��������
    public bool UpgradeSpecialAbilityDamage(int additionalDamage)
    {
        if (UpgradePoints > 0 && playerSpecialAbility != null)
        {
            UpgradePoints--;
            playerSpecialAbility.IncreaseDamage(additionalDamage);
            Debug.Log($"������� ����������� ����������� �������. �������� �������: {UpgradePoints}");
            return true;
        }
        Debug.LogWarning("�� ������� ������� ��� playerSpecialAbility �� ��������!");
        return false;
    }
}
