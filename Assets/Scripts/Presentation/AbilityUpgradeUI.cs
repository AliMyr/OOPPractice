using UnityEngine;
using UnityEngine.UI;

public class AbilityUpgradeUI : MonoBehaviour
{
    // �����, ������������ ���������� �������-�������
    public Text upgradePointsText;
    // ������ ��� ��������� ��������� � ���������������
    public Button autoAttackUpgradeButton;
    public Button specialAbilityUpgradeButton;

    // ������ �� ��������� ���������, ������� �� ����������� �����
    public AbilityUpgradeManager upgradeManager;

    // ��������, �� ������� ����� ������������� ���� ��� ��������
    [Header("Upgrade Values")]
    public int autoAttackDamageIncrease = 5;
    public int specialAbilityDamageIncrease = 10;

    private void Start()
    {
        if (upgradeManager == null)
        {
            Debug.LogError("AbilityUpgradeUI: upgradeManager �� ��������!");
            return;
        }

        // �������������� UI ����������
        UpdateUI();

        // ����������� ������ �� ��������������� ������
        autoAttackUpgradeButton.onClick.AddListener(OnAutoAttackUpgradeButtonClicked);
        specialAbilityUpgradeButton.onClick.AddListener(OnSpecialAbilityUpgradeButtonClicked);
    }

    // �����, ���������� ��� ������� ������ ��������� ���������
    public void OnAutoAttackUpgradeButtonClicked()
    {
        if (upgradeManager != null)
        {
            bool success = upgradeManager.UpgradeAutoAttackDamage(autoAttackDamageIncrease);
            if (success)
            {
                UpdateUI();
            }
        }
    }

    // �����, ���������� ��� ������� ������ ��������� ���������������
    public void OnSpecialAbilityUpgradeButtonClicked()
    {
        if (upgradeManager != null)
        {
            bool success = upgradeManager.UpgradeSpecialAbilityDamage(specialAbilityDamageIncrease);
            if (success)
            {
                UpdateUI();
            }
        }
    }

    // ��������� ��������� ����������� �������-�������
    public void UpdateUI()
    {
        if (upgradePointsText != null && upgradeManager != null)
        {
            upgradePointsText.text = "UP: " + upgradeManager.UpgradePoints;
        }
    }
}
