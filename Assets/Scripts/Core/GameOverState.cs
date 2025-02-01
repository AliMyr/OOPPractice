using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Entering Game Over State");
        // ����� ����� �������� UI Game Over, ���������� ���� � �.�.
        Time.timeScale = 0f;  // ������: ������ ���� �� �����
    }

    public void Exit()
    {
        Debug.Log("Exiting Game Over State");
        Time.timeScale = 1f;
    }

    public void Update()
    {
        // ����� �������� �������� �� ���������� ���� ��� ������� � ����
    }
}
