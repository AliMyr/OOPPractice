using System;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    // Текущий уровень игрока
    public int Level { get; private set; } = 1;
    // Текущее количество опыта
    public int CurrentExperience { get; private set; } = 0;
    // Количество опыта, необходимое для перехода на следующий уровень
    public int ExperienceToNextLevel { get; private set; } = 100;

    // Событие, которое уведомляет об увеличении уровня
    public event Action<int> OnLevelUp;

    /// <summary>
    /// Добавляем опыт. Если накопилось достаточно, выполняем повышение уровня.
    /// </summary>
    public void AddExperience(int xp)
    {
        CurrentExperience += xp;
        Debug.Log($"Получено {xp} опыта. Текущий опыт: {CurrentExperience} из {ExperienceToNextLevel}");

        // Пока опыта хватает для повышения уровня, повышаем уровень
        while (CurrentExperience >= ExperienceToNextLevel)
        {
            CurrentExperience -= ExperienceToNextLevel;
            LevelUp();
        }
    }

    /// <summary>
    /// Повышает уровень, пересчитывает требуемый опыт и оповещает подписчиков.
    /// </summary>
    private void LevelUp()
    {
        Level++;
        // Например, для повышения сложности требуемый опыт увеличивается на 1.5 раза
        ExperienceToNextLevel = Mathf.RoundToInt(ExperienceToNextLevel * 1.5f);
        Debug.Log($"Уровень повышен! Новый уровень: {Level}. Следующий уровень требует {ExperienceToNextLevel} опыта.");
        OnLevelUp?.Invoke(Level);
    }
}
