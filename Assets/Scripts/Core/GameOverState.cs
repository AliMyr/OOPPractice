using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Entering Game Over State");
        // Здесь можно включить UI Game Over, остановить игру и т.д.
        Time.timeScale = 0f;  // Пример: ставим игру на паузу
    }

    public void Exit()
    {
        Debug.Log("Exiting Game Over State");
        Time.timeScale = 1f;
    }

    public void Update()
    {
        // Можно добавить проверку на перезапуск игры или переход в меню
    }
}
