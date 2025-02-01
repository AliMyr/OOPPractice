using System;

public static class GameEvents
{
    // �������, ������� �����������, ����� ���� ����
    public static event Action OnEnemyKilled;

    // ����� ��� ������ �������, ���������, ��� ���������� ����
    public static void EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }
}
