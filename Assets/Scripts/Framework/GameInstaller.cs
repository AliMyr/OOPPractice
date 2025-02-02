using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ����������� �������� ���������, InputService � �.�.
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IInputService>().FromComponentInHierarchy().AsSingle();

        // ������ ��� SoundManager. �����: �������, ��� ������ � SoundManager ��� ���� � �����.
        Container.Bind<ISoundManager>().FromComponentInHierarchy().AsSingle();

        // ������ ��������, ��������, ��� ������� ���������
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();

        Container.Bind<SaveManager>().FromComponentInHierarchy().AsSingle();

    }
}
