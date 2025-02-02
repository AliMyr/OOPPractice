using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressionUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Text levelText;
    public Slider xpSlider;

    // Ссылка на компонент прокачки игрока (назначается через Inspector)
    public PlayerProgression playerProgression;

    private void Start()
    {
        if (playerProgression == null)
        {
            Debug.LogError("PlayerProgressionUI: Не назначен компонент PlayerProgression!");
            return;
        }

        // Инициализируем UI начальными значениями
        UpdateUI();
        // Подписываемся на событие повышения уровня
        playerProgression.OnLevelUp += OnLevelUp;
    }

    private void OnDestroy()
    {
        if (playerProgression != null)
            playerProgression.OnLevelUp -= OnLevelUp;
    }

    /// <summary>
    /// Обновляет текст уровня и значение слайдера опыта.
    /// </summary>
    private void UpdateUI()
    {
        if (levelText != null)
            levelText.text = "Level: " + playerProgression.Level;
        if (xpSlider != null)
        {
            xpSlider.maxValue = playerProgression.ExperienceToNextLevel;
            xpSlider.value = playerProgression.CurrentExperience;
        }
    }

    /// <summary>
    /// Вызывается при повышении уровня, обновляет UI.
    /// </summary>
    /// <param name="newLevel"></param>
    private void OnLevelUp(int newLevel)
    {
        UpdateUI();
    }

    // Можно также обновлять слайдер в Update(), если требуется более плавная анимация
    private void Update()
    {
        if (xpSlider != null)
            xpSlider.value = playerProgression.CurrentExperience;
    }
}
