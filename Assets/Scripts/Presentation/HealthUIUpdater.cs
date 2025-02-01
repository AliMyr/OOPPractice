using UnityEngine;
using UnityEngine.UI;

public class HealthUIUpdater : MonoBehaviour
{
    // Ссылка на компонент здоровья игрока (назначается через Inspector)
    public Health playerHealth;
    // Ссылка на UI Slider, отображающий здоровье
    public Slider healthSlider;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("HealthUIUpdater: Ссылка на Health не назначена!");
            return;
        }

        // Подписываемся на событие изменения здоровья
        playerHealth.OnHealthChanged += UpdateHealthUI;
        // Инициализируем UI начальными значениями
        healthSlider.maxValue = playerHealth.MaxHealth;
        healthSlider.value = playerHealth.MaxHealth;
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI(int newHealth)
    {
        healthSlider.value = newHealth;
    }
}
