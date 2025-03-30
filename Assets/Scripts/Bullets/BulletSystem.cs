using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem : IGameStopListener, IGameStartListener, IGamePauseListener, IGameResumeListener, IFixedUpdate
    {
        [Inject] private Transform _container;
        [Inject] private LevelBounds _levelBounds;
        [Inject] private BulletFactory _bulletFactory;
        [Inject] private PlayerController _playerController;
        [Inject] private EnemyManager _enemyManager;
        [Inject] private BulletUtils _bulletUtils;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        
        void IGameStartListener.OnStartGame()
        {
            _playerController.PlayerFire += FlyBullet;
            _enemyManager.EnemyFire += FlyBullet;
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

        public void FlyBullet(BulletConfig bulletConfig)
        {
            var bullet = _bulletFactory.Create(_container.position, bulletConfig);
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            _bulletUtils.DealDamage(bullet, collision);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.gameObject.SetActive(false);
                bullet.Die();
            }
        }
    }
}