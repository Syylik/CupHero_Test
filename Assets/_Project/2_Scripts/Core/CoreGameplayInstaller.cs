using UnityEngine;
using Zenject;

public class CoreGameplayInstaller : MonoInstaller
{
    [SerializeField] private GameLoop _gameLoop;

    public override void InstallBindings()
    {
        Container.Bind<GameLoop>().FromInstance(_gameLoop).AsSingle();
    }
}