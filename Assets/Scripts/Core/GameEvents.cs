using System;

public static class GameEvents
{
    // Уже существующее событие для убийства врагов
    public static event Action OnEnemyKilled;
    public static void EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }

    // Новое событие для Game Over
    public static event Action OnGameOver;
    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
