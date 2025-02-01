using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ����������� �������� ��������� ��� ��������
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();

        // ������ InputService: ���� ��� � �������� � ������������ ��� IInputService
        Container.Bind<IInputService>().FromComponentInHierarchy().AsSingle();

        // ������ �������� �������� ��������� PlayingState (���� �����)
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();
    }
}
