using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : IGameStopListener, IGameStartListener, IGamePauseListener, IGameResumeListener, IFixedUpdate
    {
        private int _initialCount;
        private Transform _container;
        private Bullet _prefab;
        private Transform _worldTransform;
        private LevelBounds _levelBounds;

        private readonly Queue<Bullet> _bulletPool = new();
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        public BulletSystem(GameData gameData)
        {
            _container = gameData.BulletPoolContainerTransform;
            _prefab = gameData.BulletPrefab;
            _worldTransform = gameData.WorldTransform;
            _levelBounds = gameData.LevelBounds;
            _initialCount = gameData.BulletInitialCount;
        }
        
        void IGameStartListener.OnStartGame()
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Object.Instantiate(_prefab, _container);
                _bulletPool.Enqueue(bullet);
            }
        }

        void IGamePauseListener.OnPauseGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.Rigidbody2D.simulated = false;
            }
        }

        void IGameResumeListener.OnResumeGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.Rigidbody2D.simulated = true;
            }
        }

        void IGameStopListener.OnStopGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.Rigidbody2D.simulated = false;
            }
        }
        
        void IFixedUpdate.OnFixedUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(_worldTransform);
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet = Object.Instantiate(_prefab, _worldTransform);
            }

            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.Damage = args.Damage;
            bullet.IsPlayer = args.IsPlayer;
            bullet.SetVelocity(args.Velocity);
            
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_container);
                bullet.gameObject.SetActive(false);
                _bulletPool.Enqueue(bullet);
            }
        }
        
        public struct Args
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public Color Color;
            public int PhysicsLayer;
            public int Damage;
            public bool IsPlayer;
        }
    }
}