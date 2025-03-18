using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : IDisposable
    {
        private readonly GameObject _player; 
        private readonly GameManager _gameManager;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public PlayerController(GameObject player, GameManager gameManager, 
            BulletSystem bulletSystem, BulletConfig playerBulletConfig)
        {
            _player = player;
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
            _bulletConfig = playerBulletConfig;
            
            EventManager.Instance.OnFire += OnFire;
            _player.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        private void OnFire()
        {
            OnFlyBullet();
        }

        private void OnFlyBullet()
        {
            var bulletColor = _bulletConfig.BulletColor;
            bulletColor.a = 1;
            var weapon = _player.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = bulletColor,
                Damage = _bulletConfig.Damage,
                Position = weapon.GetPosition(),
                Velocity = weapon.GetRotation() * Vector3.up * _bulletConfig.Speed
            });
        }

        public void Dispose()
        {
            EventManager.Instance.OnFire -= OnFire;
            _player.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }
    }
}