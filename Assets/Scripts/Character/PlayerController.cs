using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ShootEmUp
{
    public sealed class PlayerController : IDisposable, IGameStartListener, IGamePauseListener, IGameResumeListener
    {
        public event Action<BulletConfig> PlayerFire;
        
        [Inject] private readonly BulletSystem _bulletSystem;
        [Inject] private readonly BulletConfig _bulletConfig;
        [Inject] private readonly PlayerSpawnPoint _playerSpawnPoint;
        [Inject] private readonly WorldPositionPoint _worldPositionPoint;
        [Inject] private readonly PlayerConfig _playerConfig;
        [Inject] private readonly IPlayerFactory _playerFactory;
        [Inject] private GameData _gameData;
        
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
            if (_player.TryGetComponent(out IMovable player))
                player.MoveByRigidbodyVelocity(new Vector2(horizontalDirection, 0) * Time.fixedDeltaTime);
        }

        private void OnCharacterDeath(GameObject _) => EventManager.Instance.OnEndGameButtonClicked();

        private void OnFire()
        {
            if (_player.TryGetComponent(out IWeaponly weapon))
            {
                _bulletConfig.Position = weapon.GetPosition();
                _bulletConfig.Velocity = weapon.GetRotation() * Vector3.up * _bulletConfig.Speed;
            }

            PlayerFire?.Invoke(_bulletConfig);
        }

        private void Subscribe()
        {
            EventManager.Instance.Fire += OnFire;
            EventManager.Instance.PlayerInputChanged += OnPlayerInputChanged;
            if (_player.TryGetComponent(out IHealth health))
                health.HPEmpty += OnCharacterDeath;
        }

        private void UnSubscribe()
        {
            EventManager.Instance.Fire -= OnFire;
            EventManager.Instance.PlayerInputChanged -= OnPlayerInputChanged;
            if (!_player) return;
            if (_player.TryGetComponent(out IHealth health))
                health.HPEmpty -= OnCharacterDeath;
        }

        public void Dispose()
        {
            UnSubscribe();
            Object.Destroy(_player);
        }

    }
}