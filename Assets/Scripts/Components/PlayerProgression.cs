using System;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    // ������� ������� ������
    public int Level { get; private set; } = 1;
    // ������� ���������� �����
    public int CurrentExperience { get; private set; } = 0;
    // ���������� �����, ����������� ��� �������� �� ��������� �������
    public int ExperienceToNextLevel { get; private set; } = 100;

    // �������, ������� ���������� �� ���������� ������
    public event Action<int> OnLevelUp;

    /// <summary>
    /// ��������� ����. ���� ���������� ����������, ��������� ��������� ������.
    /// </summary>
    public void AddExperience(int xp)
    {
        CurrentExperience += xp;
        Debug.Log($"�������� {xp} �����. ������� ����: {CurrentExperience} �� {ExperienceToNextLevel}");

        // ���� ����� ������� ��� ��������� ������, �������� �������
        while (CurrentExperience >= ExperienceToNextLevel)
        {
            CurrentExperience -= ExperienceToNextLevel;
            LevelUp();
        }
    }

    /// <summary>
    /// �������� �������, ������������� ��������� ���� � ��������� �����������.
    /// </summary>
    private void LevelUp()
    {
        Level++;
        // ��������, ��� ��������� ��������� ��������� ���� ������������� �� 1.5 ����
        ExperienceToNextLevel = Mathf.RoundToInt(ExperienceToNextLevel * 1.5f);
        Debug.Log($"������� �������! ����� �������: {Level}. ��������� ������� ������� {ExperienceToNextLevel} �����.");
        OnLevelUp?.Invoke(Level);
    }
}
