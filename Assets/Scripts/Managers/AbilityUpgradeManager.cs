using UnityEngine;

public class AbilityUpgradeManager : MonoBehaviour
{
    // Количество доступных апгрейд-поинтов
    public int UpgradePoints { get; private set; } = 0;

    // Ссылки на компоненты способностей, которые нужно улучшать (назначаются через Inspector)
    public PlayerAutoAttack playerAutoAttack;
    public PlayerSpecialAbility playerSpecialAbility;

    // Подписываемся на событие повышения уровня игрока
    // Предполагаем, что компонент PlayerProgression уже есть у игрока
    public void Initialize(PlayerProgression progression)
    {
        if (progression != null)
        {
            progression.OnLevelUp += OnPlayerLevelUp;
        }
        else
        {
            Debug.LogError("AbilityUpgradeManager: PlayerProgression не назначен!");
        }
    }

    // Вызывается при повышении уровня игрока – добавляем один апгрейд-поинт
    private void OnPlayerLevelUp(int newLevel)
    {
        UpgradePoints++;
        Debug.Log($"Получен апгрейд-поинт! Всего теперь: {UpgradePoints}");
        // Здесь можно уведомить UI о наличии новых поинтов
    }

    // Метод для улучшения автоатаки: увеличивает урон на заданное значение
    public bool UpgradeAutoAttackDamage(int additionalDamage)
    {
        if (UpgradePoints > 0 && playerAutoAttack != null)
        {
            UpgradePoints--;
            playerAutoAttack.IncreaseDamage(additionalDamage);
            Debug.Log($"Апгрейд автоатаки применён. Осталось поинтов: {UpgradePoints}");
            return true;
        }
        Debug.LogWarning("Не хватает поинтов или playerAutoAttack не назначен!");
        return false;
    }

    // Метод для улучшения специальной способности: увеличивает урон на заданное значение
    public bool UpgradeSpecialAbilityDamage(int additionalDamage)
    {
        if (UpgradePoints > 0 && playerSpecialAbility != null)
        {
            UpgradePoints--;
            playerSpecialAbility.IncreaseDamage(additionalDamage);
            Debug.Log($"Апгрейд специальной способности применён. Осталось поинтов: {UpgradePoints}");
            return true;
        }
        Debug.LogWarning("Не хватает поинтов или playerSpecialAbility не назначен!");
        return false;
    }
}
