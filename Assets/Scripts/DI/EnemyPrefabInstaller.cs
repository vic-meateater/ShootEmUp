using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyPrefabInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private Transform _enemyPoolContainer;
        [SerializeField] private EnemyPositions _enemyPositions;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindInstance(_enemyPositions).AsSingle(); 
            Container.Bind<Transform>().FromInstance(_enemyPoolContainer).WhenInjectedInto<EnemyPool>();
            Container.BindMemoryPool<Enemy, EnemyPool>()
                .WithMaxSize(100)
                .FromComponentInNewPrefab(_config.EnemyPrefab)
                .UnderTransform(_enemyPoolContainer);
            Container.Bind<EnemyFactory>().AsSingle();
        }
    }
}