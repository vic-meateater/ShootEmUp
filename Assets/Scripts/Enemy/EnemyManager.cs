using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager : IGameStopListener, IGameStartListener, IGamePauseListener, IGameResumeListener, IFixedUpdate
    {
        public event Action<BulletConfig> EnemyFire;
        
        [Inject] private readonly EnemyConfig _enemyConfig;
        [Inject] private readonly EnemyFactory _enemyFactory;
        [Inject] private readonly EnemyPositions _enemyPositions;
        [Inject] private readonly BulletSystem _bulletSystem;
        [Inject] private readonly BulletConfig _bulletConfig;
        [Inject] private readonly UpdateController _updateController;
        [Inject] private readonly GameData _gameData;
        
        private Player _player;
        private Coroutine _spawnCoroutine;
        private bool _isSpawning;
        private float _spawnCooldown = 1.0f;
        private float _nextSpawnTime = 0f;
        
        private readonly HashSet<GameObject> _activeEnemies = new();

        void IGameStartListener.OnStartGame()
        {
            _player = _gameData.Player;
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
            if (!_isSpawning || Time.time < _nextSpawnTime || _activeEnemies.Count >= _enemyPositions.GetPositionCount()) 
                return;

            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnCooldown; 
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.Create(_enemyPositions.RandomSpawnPosition().position, _enemyConfig).gameObject;
            if (enemy && _activeEnemies.Add(enemy))
            {
                Debug.Log($"{enemy.name} Заспавнился");
                var attackPosition = _enemyPositions.RandomAttackPosition();
                if (enemy.TryGetComponent(out IAttackAgent enemyAttackAgent))
                {
                    enemyAttackAgent.OnFire += OnFire;
                    enemyAttackAgent.SetTarget(_player.gameObject);
                }

                if(enemy.TryGetComponent(out IMoveAgent enemyMoveAgent))
                    enemyMoveAgent.SetDestination(attackPosition.position);
                
                if(enemy.TryGetComponent(out IHealth enemyHealth))
                    enemyHealth.HPEmpty += OnDestroyed;
                
                AddFixedUpdate(enemy.gameObject);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletConfig.Position = position;
            _bulletConfig.Velocity = direction * 2.0f;
            EnemyFire?.Invoke(_bulletConfig);
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
                if(enemy.TryGetComponent(out IHealth enemyHealth))
                    enemyHealth.HPEmpty -= OnDestroyed;
                if (enemy.TryGetComponent(out IAttackAgent enemyAttackAgent))
                    enemyAttackAgent.OnFire -= OnFire;
                enemy.GetComponent<Enemy>().Die();
                RemoveFixedUpdate(enemy);
            }
        }
    }
}