using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletFactory : IFactory<Vector3, BulletConfig, Bullet>
    {
        [Inject] private readonly BulletPool _bulletPool;
        
        public Bullet Create(Vector3 position, BulletConfig config)
        {
            var bulletColor = config.BulletColor;
            bulletColor.a = 1;
            var bullet = _bulletPool.Spawn(position);
            bullet.SetPosition(config.Position);
            bullet.SetColor(bulletColor);
            bullet.SetPhysicsLayer((int)config.PhysicsLayer);
            bullet.SetVelocity(config.Velocity);
            bullet.SetDamage(config.Damage);
            bullet.SetIsPlayer(config.IsPlayer);
            return bullet;
        }
    }
}