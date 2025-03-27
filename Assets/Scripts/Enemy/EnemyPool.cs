using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootEmUp
{
    public sealed class EnemyPool
    {
        private Transform _worldTransform;
        private Transform _container;
        private GameObject _enemyPrefab;
        
        private readonly Queue<GameObject> _enemyPool = new();
        private readonly int _poolSize;

        public EnemyPool(GameData gameData)
        {
            _worldTransform = gameData.WorldTransform;
            _container = gameData.EnemyPoolContainerTransform;
            _enemyPrefab = gameData.EnemyPrefab;
            _poolSize = gameData.EnemyPositions.GetPositionCount();

            InstantiatePool();
        }
        
        private void InstantiatePool()
        {
            for (var i = 0; i < _poolSize; i++)
            {
                var enemy = Object.Instantiate(_enemyPrefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }
            enemy.SetActive(true);
            enemy.transform.SetParent(_worldTransform);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            enemy.SetActive(false);
            _enemyPool.Enqueue(enemy);
        }
    }
}