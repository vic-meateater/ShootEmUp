using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ShootEmUp
{
    public class BulletPrefabInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _bulletPoolMaxSize;
        [SerializeField] private Transform _bulletPoolContainer;
        [SerializeField] private BulletConfig _playerBulletConfig;
        [SerializeField] private BulletConfig _enemyBulletConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_bulletPrefab).AsSingle();
            Container.BindInstance(_bulletPoolMaxSize);
            Container.Bind<Transform>().FromInstance(_bulletPoolContainer).WhenInjectedInto<BulletSystem>();
            Container.BindInstance(_playerBulletConfig).WhenInjectedInto<PlayerController>();
            Container.BindInstance(_enemyBulletConfig).WhenInjectedInto<EnemyManager>();
            Container.BindMemoryPool<Bullet, BulletPool>()
                .WithMaxSize(_bulletPoolMaxSize)
                .FromComponentInNewPrefab(_bulletPrefab)
                .UnderTransform(_bulletPoolContainer);
            Container.Bind<BulletFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletSystem>().FromNew().AsSingle();
            Container.Bind<BulletUtils>().FromNew().AsSingle();
        }
    }
}