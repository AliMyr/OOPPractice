using UnityEngine;
using UnityEngine.UI;

public class AbilityUpgradeUI : MonoBehaviour
{
    // Текст, отображающий количество апгрейд-поинтов
    public Text upgradePointsText;
    // Кнопки для улучшения автоатаки и спецспособности
    public Button autoAttackUpgradeButton;
    public Button specialAbilityUpgradeButton;

    // Ссылка на менеджера апгрейдов, который мы реализовали ранее
    public AbilityUpgradeManager upgradeManager;

    // Значения, на которые будут увеличиваться урон при апгрейде
    [Header("Upgrade Values")]
    public int autoAttackDamageIncrease = 5;
    public int specialAbilityDamageIncrease = 10;

    private void Start()
    {
        if (upgradeManager == null)
        {
            Debug.LogError("AbilityUpgradeUI: upgradeManager не назначен!");
            return;
        }

        // Инициализируем UI значениями
        UpdateUI();

        // Подписываем кнопки на соответствующие методы
        autoAttackUpgradeButton.onClick.AddListener(OnAutoAttackUpgradeButtonClicked);
        specialAbilityUpgradeButton.onClick.AddListener(OnSpecialAbilityUpgradeButtonClicked);
    }

    // Метод, вызываемый при нажатии кнопки улучшения автоатаки
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

    // Метод, вызываемый при нажатии кнопки улучшения спецспособности
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

    // Обновляем текстовое отображение апгрейд-поинтов
    public void UpdateUI()
    {
        if (upgradePointsText != null && upgradeManager != null)
        {
            upgradePointsText.text = "UP: " + upgradeManager.UpgradePoints;
        }
    }
}
