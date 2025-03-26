using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootEmUp
{
    public sealed class PlayerController : IDisposable, IGameStartListener, IGamePauseListener, IGameResumeListener
    {
        private readonly GameObject _player; 
        private readonly GameManager _gameManager;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public PlayerController(GameObject playerPrefab, GameManager gameManager, 
            BulletSystem bulletSystem, BulletConfig playerBulletConfig, Transform playerSpawnTransform, GameData gameData)
        {
            _player = Object.Instantiate(playerPrefab, playerSpawnTransform.position, Quaternion.identity, gameData.WorldTransform);
            gameData.Player = _player;
            _gameManager = gameManager;
            _bulletSystem = bulletSystem;
            _bulletConfig = playerBulletConfig;
        }

        void IGameStartListener.OnStartGame()
        {
            Subscribe();
        }

        void IGamePauseListener.OnPauseGame()
        {
            UnSubscribe();
        }

        void IGameResumeListener.OnResumeGame()
        {
            Subscribe();
        }
        
        private void OnPlayerInputChanged(float horizontalDirection)
        {
            _player.TryGetComponent(out MoveComponent player);
            player.MoveByRigidbodyVelocity(new Vector2(horizontalDirection, 0) * Time.fixedDeltaTime);
        }

        private void OnCharacterDeath(GameObject _) => EventManager.Instance.OnEndGameButtonClicked();

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
        private void Subscribe()
        {
            EventManager.Instance.Fire += OnFire;
            EventManager.Instance.PlayerInputChanged += OnPlayerInputChanged;
            _player.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        private void UnSubscribe()
        {
            EventManager.Instance.Fire -= OnFire;
            EventManager.Instance.PlayerInputChanged -= OnPlayerInputChanged;
            _player.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }

        public void Dispose()
        {
            UnSubscribe();
        }

    }
}