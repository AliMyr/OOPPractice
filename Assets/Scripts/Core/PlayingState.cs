using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        Debug.Log("Entering Playing State");
        // Можно включить игровой UI, запустить логики, активировать врагов и т.д.
    }

    public void Exit()
    {
        Debug.Log("Exiting Playing State");
        // Выключить UI, остановить игровые процессы и т.д.
    }

    public void Update()
    {
        // Логика, выполняемая каждый кадр в состоянии игры.
    }
}
