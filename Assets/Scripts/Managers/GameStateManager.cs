using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private IGameState currentState;

    // Метод для смены состояния
    public void ChangeState(IGameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Update();
    }
}
