using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityUI : MonoBehaviour
{
    [Tooltip("Ссылка на компонент специальной способности игрока.")]
    public PlayerSpecialAbility specialAbility;
    [Tooltip("UI-элемент Slider, который отображает прогресс кулдауна (value от 0 до 1).")]
    public Slider cooldownSlider;

    private void Start()
    {
        if (cooldownSlider != null)
        {
            // Устанавливаем минимальное и максимальное значения слайдера
            cooldownSlider.minValue = 0f;
            cooldownSlider.maxValue = 1f;
        }
    }

    private void Update()
    {
        if (specialAbility == null || cooldownSlider == null)
            return;

        // Обновляем значение слайдера согласно прогрессу кулдауна
        cooldownSlider.value = specialAbility.GetCooldownProgress();
    }
}
