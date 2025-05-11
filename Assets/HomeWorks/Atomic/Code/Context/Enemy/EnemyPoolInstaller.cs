using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic.Enemy
{
    [Serializable]
    public class EnemyPoolInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new EnemyPoolController());
        }
    }

    public class EnemyPoolController : IContextInit
    {
        private EnemyService _enemyService;
        private GameObjectSpawner _spawner;
        private List<Transform> _parents;
        private int _poolSize;
        private Queue<GameObject> _enemiesPool = new Queue<GameObject>();

        public void Init(IContext context)
        {
            _enemyService = context.GetGameServices().EnemyService;
            _spawner = context.GetGameObjectSpawner();
            _parents = context.GetEnemyPools();
            _poolSize = _enemyService.EnemyConfig.PoolSize;

            PoolInit();
            FirstZombieRun();
        }

        private void PoolInit()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                foreach (var parent in _parents)
                {
                    var enemy = _spawner.SpawnGameObject(
                        _enemyService.EnemyConfig.Prefab,
                        parent,
                        parent);
                    enemy.SetActive(false);
                    _enemiesPool.Enqueue(enemy);
                }
            }
        }

        private void RunZombieRun()
        {
            var enemy = _enemiesPool.Dequeue();
            enemy.SetActive(true);

            if (enemy.TryGetEntity(out var enemyEntity))
            {
                var deadZombie = enemyEntity.GetIsDead();
                deadZombie.OnValueChanged += (value) => OnIsDeadAction(value, enemy);
            }
        }

        private void FirstZombieRun()
        {
            for (int i = 0; i < _parents.Count; i++)
            {
                RunZombieRun();
            }
        }

        private void OnIsDeadAction(bool isDead, GameObject deadZombie)
        {
            deadZombie.SetActive(false);
            _enemiesPool.Enqueue(deadZombie);
            RunZombieRun();
        }
    }
}