using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool: MonoMemoryPool<Vector3, Enemy>
    {
        // [Inject] private EnemyPositions _enemyPositions;
        // [Inject] private WorldPositionPoint _worldPositionPoint;
        // [Inject] private GameData _gameData;
        // [Inject] private EnemyConfig _enemyConfig;
        // [Inject] private Transform _enemyPoolContainer;
        //private GameObject _enemyPrefab;

        protected override void Reinitialize(Vector3 position, Enemy enemy)
        {
            enemy.transform.position = position;
            enemy.gameObject.SetActive(true);
            enemy.SetPool(this);
        }

        protected override void OnDespawned(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        // private readonly Queue<GameObject> _enemyPool = new();
        // private int _poolSize;
        //
        // [Inject]
        // private void Init()
        // {
        //     _enemyPrefab = _enemyConfig.EnemyPrefab.gameObject;
        //     _poolSize = _enemyPositions.GetPositionCount();
        // }
        // public void OnStartGame()
        // {
        //     InstantiatePool();
        // }
        //
        // private void InstantiatePool()
        // {
        //     for (var i = 0; i < _poolSize; i++)
        //     {
        //         var enemy = Object.Instantiate(_enemyPrefab, _enemyPoolContainer);
        //         _enemyPool.Enqueue(enemy);
        //     }
        // }
        //
        // public GameObject SpawnEnemy()
        // {
        //     if (!_enemyPool.TryDequeue(out var enemy))
        //     {
        //         return null;
        //     }
        //     enemy.gameObject.SetActive(true);
        //     enemy.transform.SetParent(_worldPositionPoint.Transform);
        //     return enemy.gameObject;
        // }
        //
        // public void UnspawnEnemy(GameObject enemy)
        // {
        //     enemy.transform.SetParent(_enemyPoolContainer);
        //     enemy.gameObject.SetActive(false);
        //     _enemyPool.Enqueue(enemy);
        // }

    }
}