using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityUI : MonoBehaviour
{
    [Tooltip("������ �� ��������� ����������� ����������� ������.")]
    public PlayerSpecialAbility specialAbility;
    [Tooltip("UI-������� Slider, ������� ���������� �������� �������� (value �� 0 �� 1).")]
    public Slider cooldownSlider;

    private void Start()
    {
        if (cooldownSlider != null)
        {
            // ������������� ����������� � ������������ �������� ��������
            cooldownSlider.minValue = 0f;
            cooldownSlider.maxValue = 1f;
        }
    }

    private void Update()
    {
        if (specialAbility == null || cooldownSlider == null)
            return;

        // ��������� �������� �������� �������� ��������� ��������
        cooldownSlider.value = specialAbility.GetCooldownProgress();
    }
}
