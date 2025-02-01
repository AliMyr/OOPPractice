using UnityEngine;
using Zenject;

public class GameOverController : MonoBehaviour
{
    [Inject]
    private GameStateManager gameStateManager;

    // ������ �� ��������� �������� ������ (����������� ����� Inspector)
    public Health playerHealth;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("GameOverController: �� �������� ��������� Health ������!");
            return;
        }

        // ������������� �� ������� ������ ������
        playerHealth.OnDied += OnPlayerDied;
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        // ��� ������ ������ ����������� ��������� �� Game Over
        gameStateManager.ChangeState(new GameOverState());
    }
}
