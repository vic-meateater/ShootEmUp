using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyPrefabInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private int _enemyPoolMaxSize;
        [SerializeField] private Transform _enemyPoolContainer;
        [SerializeField] private EnemyPositions _enemyPositions;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_enemyConfig);
            Container.BindInstance(_enemyPoolMaxSize);
            Container.BindInstance(_enemyPositions).AsSingle(); 
            Container.Bind<Transform>().FromInstance(_enemyPoolContainer).WhenInjectedInto<EnemyPool>();
            Container.BindMemoryPool<Enemy, EnemyPool>()
                .WithMaxSize(_enemyPoolMaxSize)
                .FromComponentInNewPrefab(_enemyConfig.EnemyPrefab)
                .UnderTransform(_enemyPoolContainer);
            Container.Bind<EnemyFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyManager>().FromNew().AsSingle();
        }
    }
}