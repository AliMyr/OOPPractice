using UnityEngine;
using Zenject;

public class GameOverController : MonoBehaviour
{
    [Inject]
    private GameStateManager gameStateManager;

    // Ссылка на компонент здоровья игрока (назначается через Inspector)
    public Health playerHealth;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("GameOverController: Не назначен компонент Health игрока!");
            return;
        }

        // Подписываемся на событие смерти игрока
        playerHealth.OnDied += OnPlayerDied;
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        // При смерти игрока переключаем состояние на Game Over
        gameStateManager.ChangeState(new GameOverState());
    }
}
