using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : IGameStopListener, IGameStartListener, IGamePauseListener, IGameResumeListener, IFixedUpdate
    {
        private readonly EnemyPool _enemyPool;
        private readonly EnemyPositions _enemyPositions;
        private readonly GameObject _player;
        private readonly BulletSystem _bulletSystem;
        private readonly UpdateController _updateController;
        
        private Coroutine _spawnCoroutine;
        private bool _isSpawning = false;
        private float _spawnCooldown = 1.0f;
        private float _nextSpawnTime = 0f;

        public EnemyManager(EnemyPool enemyPool, 
                            GameData gameData, 
                            BulletSystem bulletSystem, 
                            UpdateController updateController)
        {
            _enemyPool = enemyPool;
            _bulletSystem = bulletSystem;
            _player = gameData.Player;
            _enemyPositions = gameData.EnemyPositions;
            _updateController = updateController;
        }
        
        private readonly HashSet<GameObject> _activeEnemies = new();

        void IGameStartListener.OnStartGame()
        {
            _isSpawning = true;
        }
        void IGamePauseListener.OnPauseGame()
        {
            _isSpawning = false;
            foreach (var enemy in _activeEnemies)
            {
                RemoveFixedUpdate(enemy);
            }
        }
        void IGameResumeListener.OnResumeGame()
        {
            _isSpawning = true;
            foreach (var enemy in _activeEnemies)
            {
                AddFixedUpdate(enemy);
            }
        }

        void IGameStopListener.OnStopGame()
        {
            _isSpawning = false;
        }
        
        void IFixedUpdate.OnFixedUpdate()
        {
            if (!_isSpawning || Time.time < _nextSpawnTime) return;

            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnCooldown; 
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyPool.SpawnEnemy();
            if (enemy != null && _activeEnemies.Add(enemy))
            {
                var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
                var enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();

                enemy.GetComponent<HitPointsComponent>().hpEmpty += OnDestroyed;
                enemyAttackAgent.OnFire += OnFire;

                var spawnPosition = _enemyPositions.RandomSpawnPosition();
                enemy.transform.position = spawnPosition.position;
                var attackPosition = _enemyPositions.RandomAttackPosition();

                enemyMoveAgent.SetDestination(attackPosition.position);
                enemyAttackAgent.SetTarget(_player);

                AddFixedUpdate(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                Color = Color.red,
                Damage = 1,
                Position = position,
                Velocity = direction * 2.0f
            });
        }
        private void AddFixedUpdate(GameObject enemy)
        {
            var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
            var enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();
            
            _updateController.AddUpdateable(enemyMoveAgent);
            _updateController.AddUpdateable(enemyAttackAgent);
        }
        private void RemoveFixedUpdate(GameObject enemy)
        {
            var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
            var enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();

            _updateController.RemoveUpdateable(enemyAttackAgent);
            _updateController.RemoveUpdateable(enemyMoveAgent);
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
                
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= OnDestroyed;
                enemyAttackAgent.OnFire -= OnFire;
                _enemyPool.UnspawnEnemy(enemy);
                
                RemoveFixedUpdate(enemy);
            }
        }
    }
}
