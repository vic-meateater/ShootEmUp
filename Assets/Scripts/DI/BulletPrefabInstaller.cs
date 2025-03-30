using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletPrefabInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_bulletConfig).AsSingle();
            Container.Bind<Bullet>().FromInstance(_bulletPrefab).AsSingle();
        }
    }
}