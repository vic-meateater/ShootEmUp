using Atomic.Contexts;
using UnityEngine;


namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private GameObjectSpawner _gameObjectSpawner;
        [SerializeField] private PlayerInputInstaller _playerInputInstaller;
        [SerializeField] private UIViewInstaller _uiViewInstaller;
        [SerializeField] private GameServices _gameServices;

        public override void Install(IContext context)
        {
            context.AddPlayerSpawner(_playerSpawner);
            context.AddGameObjectSpawner(_gameObjectSpawner);
            context.AddGameServices(_gameServices);

            context.AddSystem(new PlayerSpawnerController());
            _playerInputInstaller.Install(context);
            _uiViewInstaller.Install(context);
        }
    }
}