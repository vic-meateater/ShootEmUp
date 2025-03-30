using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        
        public void SetPool(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void Die()
        {
            _enemyPool.Despawn(this);
        }
    }
}