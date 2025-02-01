using UnityEngine;
using UnityEngine.UI;

public class HealthUIUpdater : MonoBehaviour
{
    // ������ �� ��������� �������� ������ (����������� ����� Inspector)
    public Health playerHealth;
    // ������ �� UI Slider, ������������ ��������
    public Slider healthSlider;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("HealthUIUpdater: ������ �� Health �� ���������!");
            return;
        }

        // ������������� �� ������� ��������� ��������
        playerHealth.OnHealthChanged += UpdateHealthUI;
        // �������������� UI ���������� ����������
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
