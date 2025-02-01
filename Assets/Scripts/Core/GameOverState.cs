using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Entering Game Over State");
        Time.timeScale = 0f;  // Ставим игру на паузу
        GameEvents.GameOver(); // Уведомляем все подписанные системы, что игра окончена
    }

    public void Exit()
    {
        Debug.Log("Exiting Game Over State");
        Time.timeScale = 1f;
    }

    public void Update()
    {
        // Здесь можно добавить логику, например, ожидание нажатия кнопки для перезапуска
    }
}
