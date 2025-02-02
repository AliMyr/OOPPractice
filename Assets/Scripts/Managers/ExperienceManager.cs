using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience Settings")]
    // Количество опыта, которое игрок получает за убийство врага
    public int experiencePerEnemy = 50;
    // Ссылка на компонент прокачки игрока (назначается через Inspector)
    public PlayerProgression playerProgression;

    private void OnEnable()
    {
        // Подписываемся на глобальное событие убийства врага
        GameEvents.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        if (playerProgression != null)
        {
            Debug.Log("Enemy killed! Добавляем опыт игроку.");
            playerProgression.AddExperience(experiencePerEnemy);
        }
        else
        {
            Debug.LogWarning("ExperienceManager: Ссылка на PlayerProgression не назначена!");
        }
    }
}
