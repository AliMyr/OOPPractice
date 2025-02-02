using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Привязываем менеджер состояний, InputService и т.д.
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IInputService>().FromComponentInHierarchy().AsSingle();

        // Биндим наш SoundManager. Важно: убедись, что объект с SoundManager уже есть в сцене.
        Container.Bind<ISoundManager>().FromComponentInHierarchy().AsSingle();

        // Другие биндинги, например, для игровых состояний
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();

        Container.Bind<SaveManager>().FromComponentInHierarchy().AsSingle();

    }
}
