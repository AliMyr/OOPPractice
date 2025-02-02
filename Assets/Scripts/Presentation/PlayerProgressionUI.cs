using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressionUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Text levelText;
    public Slider xpSlider;

    // ������ �� ��������� �������� ������ (����������� ����� Inspector)
    public PlayerProgression playerProgression;

    private void Start()
    {
        if (playerProgression == null)
        {
            Debug.LogError("PlayerProgressionUI: �� �������� ��������� PlayerProgression!");
            return;
        }

        // �������������� UI ���������� ����������
        UpdateUI();
        // ������������� �� ������� ��������� ������
        playerProgression.OnLevelUp += OnLevelUp;
    }

    private void OnDestroy()
    {
        if (playerProgression != null)
            playerProgression.OnLevelUp -= OnLevelUp;
    }

    /// <summary>
    /// ��������� ����� ������ � �������� �������� �����.
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
    /// ���������� ��� ��������� ������, ��������� UI.
    /// </summary>
    /// <param name="newLevel"></param>
    private void OnLevelUp(int newLevel)
    {
        UpdateUI();
    }

    // ����� ����� ��������� ������� � Update(), ���� ��������� ����� ������� ��������
    private void Update()
    {
        if (xpSlider != null)
            xpSlider.value = playerProgression.CurrentExperience;
    }
}
