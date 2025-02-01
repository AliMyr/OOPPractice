using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Привязываем менеджер состояний как синглтон
        Container.Bind<GameStateManager>().FromComponentInHierarchy().AsSingle();

        // Биндим InputService: ищем его в иерархии и регистрируем как IInputService
        Container.Bind<IInputService>().FromComponentInHierarchy().AsSingle();

        // Пример биндинга игрового состояния PlayingState (если нужно)
        Container.Bind<IGameState>().To<PlayingState>().AsTransient();
    }
}
