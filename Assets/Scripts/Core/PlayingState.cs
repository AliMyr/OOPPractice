using UnityEngine;

public class PlayingState : IGameState
{
    public void Enter()
    {
        Debug.Log("Entering Playing State");
        // ����� �������� ������� UI, ��������� ������, ������������ ������ � �.�.
    }

    public void Exit()
    {
        Debug.Log("Exiting Playing State");
        // ��������� UI, ���������� ������� �������� � �.�.
    }

    public void Update()
    {
        // ������, ����������� ������ ���� � ��������� ����.
    }
}
