using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ShootEmUp
{
    public sealed class PlayerController : IDisposable, IGameStartListener, IGamePauseListener, IGameResumeListener
    {
        [Inject] private BulletSystem _bulletSystem;
        [Inject] private BulletConfig _bulletConfig;
        [Inject] private PlayerSpawnPoint _playerSpawnPoint;
        [Inject] private WorldPositionPoint _worldPositionPoint;
        [Inject] private GameData _gameData;
        [Inject] private PlayerConfig _playerConfig;
        [Inject] private IPlayerFactory _playerFactory;
        
        private Player _player;

        [Inject]
        private void Init()
        {
            _player = _playerFactory.CreatePlayer(_playerSpawnPoint.Transform.position, _worldPositionPoint.Transform);
            _gameData.Player = _player;
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
            if (_player)
                _player.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }

        public void Dispose()
        {
            UnSubscribe();
            Object.Destroy(_player);
        }

    }
}