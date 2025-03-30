using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyFactory : IFactory<Vector3, Enemy>
    {
        [Inject] private readonly EnemyPool _enemyPool;

        public Enemy Create(Vector3 position)
        {
            return _enemyPool.Spawn(position);
        }
    }
}