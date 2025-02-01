using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Пример биндинга менеджера состояний как синглтона
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();

        // Если есть глобальные сервисы, их можно зарегать так:
        // Container.Bind<IInputService>().To<InputService>().AsSingle();
        // Container.Bind<IUIManager>().To<UIManager>().AsSingle();

        // Для примера, пусть PlayingState создаётся как transient (новый экземпляр каждый раз)
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();
    }
}
