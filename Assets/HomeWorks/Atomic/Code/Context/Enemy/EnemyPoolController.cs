using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic.Enemy
{
    public class EnemyPoolController : IContextInit, IContextUpdate
    {
        private EnemyService _enemyService;
        private PlayerService _playerService;
        private GameObjectSpawner _spawner;
        private List<Transform> _parents;
        private int _poolSize;
        private Queue<GameObject> _enemiesPool = new Queue<GameObject>();
        private float _respawnTimer;

        public void Init(IContext context)
        {
            _enemyService = context.GetGameServices().EnemyService;
            _playerService = context.GetGameServices().PlayerService;
            _spawner = context.GetGameObjectSpawner();
            _parents = context.GetEnemyPools();
            _poolSize = _enemyService.EnemyConfig.PoolSize;
            _respawnTimer = 0f;

            PoolInit();
        }

        private void PoolInit()
        {
            _enemiesPool.Clear();
            for (int i = 0; i < _poolSize; i++)
            {
                foreach (var parent in _parents)
                {
                    var enemy = _spawner.SpawnGameObject(
                        _enemyService.EnemyConfig.Prefab,
                        parent,
                        parent);
                    enemy.SetActive(false);
                    enemy.TryGetEntity(out IEntity entity);
                    if(entity != null)
                        entity.GetParentPosition().Value = parent.position;
                    _enemiesPool.Enqueue(enemy);
                }
            }
        }

        private void RunZombieRun()
        {
#if UNITY_EDITOR
            if (_enemiesPool.Count == 0)
            {
                Debug.LogWarning("No enemies in pool!");
                return;
            }
#endif
            var enemy = _enemiesPool.Dequeue();

            if (enemy.TryGetEntity(out var enemyEntity))
            {
                enemyEntity.OnInitialized += () => EnemyOnInit(enemyEntity);
                var deadZombieEvent = enemyEntity.GetCharacterDieEvent();
                deadZombieEvent.OnEvent += () => OnIsDeadAction(enemy, enemyEntity);
            }
            enemy.GetComponent<Collider>().enabled = true;
            enemy.SetActive(true);
        }

        private void EnemyOnInit(IEntity enemyEntity)
        {
            enemyEntity.GetSpawnedEvent()?.Invoke(_playerService.Player);
        }
        
        private void OnIsDeadAction(GameObject enemy, IEntity entity)
        {
            enemy.SetActive(false);
            enemy.transform.position = entity.GetParentPosition().Value;
            _enemiesPool.Enqueue(enemy);
        }

        public void Update(IContext context, float deltaTime)
        {
            var respawnInterval = context.GetGameServices().EnemyService.EnemyConfig.RespawnInterval;
            _respawnTimer += deltaTime;
            if (_respawnTimer >= respawnInterval)
            {
                RunZombieRun();
                _respawnTimer = 0f;
            }
        }
    }
}