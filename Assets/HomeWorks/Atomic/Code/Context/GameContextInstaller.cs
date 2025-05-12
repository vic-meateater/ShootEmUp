using System.Collections.Generic;
using Atomic.Contexts;
using ShootEmUp.HomeWorks.Atomic.Enemy;
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
        [SerializeField] private WeaponContextInstaller _weaponInstaller;
        [SerializeField] private BulletPoolInstaller _bulletsPoolInstaller;
        [SerializeField] private Transform _bulletsPool;
        [SerializeField] private EnemyPoolInstaller _enemyPoolInstaller;
        [SerializeField] private List<Transform> _enemyPools;

        public override void Install(IContext context)
        {
            context.AddPlayerSpawner(_playerSpawner);
            context.AddGameObjectSpawner(_gameObjectSpawner);
            context.AddGameServices(_gameServices);
            context.AddBulletsPool(_bulletsPool);
            context.AddEnemyPools(_enemyPools);

            context.AddSystem(new PlayerSpawnerController());
            _playerInputInstaller.Install(context);
            _weaponInstaller.Install(context);
            _bulletsPoolInstaller.Install(context);
            _uiViewInstaller.Install(context);
            _enemyPoolInstaller.Install(context);
        }
    }
}