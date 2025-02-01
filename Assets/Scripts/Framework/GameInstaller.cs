using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ������ �������� ��������� ��������� ��� ���������
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();

        // ���� ���� ���������� �������, �� ����� �������� ���:
        // Container.Bind<IInputService>().To<InputService>().AsSingle();
        // Container.Bind<IUIManager>().To<UIManager>().AsSingle();

        // ��� �������, ����� PlayingState �������� ��� transient (����� ��������� ������ ���)
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();
    }
}
