using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager : IGameStopListener, IGameStartListener, IGamePauseListener, IGameResumeListener, IFixedUpdate
    {
        [Inject] private readonly EnemyFactory _enemyFactory;
        [Inject] private EnemyPositions _enemyPositions;
        [Inject] private readonly BulletSystem _bulletSystem;
        [Inject] private readonly UpdateController _updateController;
        [Inject] private GameData _gameData;
        
        private Player _player;
        private Coroutine _spawnCoroutine;
        private bool _isSpawning;
        private float _spawnCooldown = 1.0f;
        private float _nextSpawnTime = 0f;
        
        [Inject]
        private void Init()
        {
            _player = _gameData.Player;
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
            if (!_isSpawning || Time.time < _nextSpawnTime || _activeEnemies.Count >= _enemyPositions.GetPositionCount()) 
                return;

            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnCooldown; 
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyFactory.Create(_enemyPositions.RandomSpawnPosition().position).gameObject;
            if (enemy != null && _activeEnemies.Add(enemy))
            {
                Debug.Log($"{enemy.name} Заспавнился");
                var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
                var enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();

                enemy.GetComponent<HitPointsComponent>().hpEmpty += OnDestroyed;
                enemyAttackAgent.OnFire += OnFire;

                // var spawnPosition = _enemyPositions.RandomSpawnPosition();
                // enemy.transform.position = spawnPosition.position;
                var attackPosition = _enemyPositions.RandomAttackPosition();

                enemyMoveAgent.SetDestination(attackPosition.position);
                enemyAttackAgent.SetTarget(_player.gameObject);

                AddFixedUpdate(enemy.gameObject);
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
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= OnDestroyed;
                var enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
                enemyAttackAgent.OnFire -= OnFire;
                enemy.GetComponent<Enemy>().Die();
                RemoveFixedUpdate(enemy);
            }
        }
    }
}
