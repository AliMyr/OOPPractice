using System;

public static class GameEvents
{
    // Событие, которое срабатывает, когда враг убит
    public static event Action OnEnemyKilled;

    // Метод для вызова события, проверяем, что подписчики есть
    public static void EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }
}
