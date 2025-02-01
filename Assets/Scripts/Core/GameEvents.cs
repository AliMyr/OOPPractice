using System;

public static class GameEvents
{
    // ��� ������������ ������� ��� �������� ������
    public static event Action OnEnemyKilled;
    public static void EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }

    // ����� ������� ��� Game Over
    public static event Action OnGameOver;
    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
