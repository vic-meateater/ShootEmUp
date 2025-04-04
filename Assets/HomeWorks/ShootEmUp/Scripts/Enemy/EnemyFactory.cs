using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyFactory : IFactory<Vector3, EnemyConfig, Enemy>
    {
        [Inject] private readonly EnemyPool _enemyPool;

        public Enemy Create(Vector3 position, EnemyConfig config)
        {
            var enemy = _enemyPool.Spawn(position);
            if (enemy.TryGetComponent(out IHealth enemyHealth))
                    enemyHealth.SetHealth(config.HealthPoints);
            if (enemy.TryGetComponent(out ISpeedChangeable speed))
                    speed.SetSpeed(config.Speed);
            
            return enemy;
        }
    }
}