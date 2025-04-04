using UnityEngine;

namespace ShootEmUp
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly Player _playerPrefab;
        private readonly PlayerConfig _config;

        public PlayerFactory(PlayerConfig config)
        {
            _playerPrefab = config.PlayerPrefab;
            _config = config;
        }

        public Player CreatePlayer(Vector3 position, Transform parent)
        {
            Player player = Object.Instantiate(_playerPrefab, position, Quaternion.identity, parent);

            if (player.TryGetComponent(out IHealth enemyHealth))
                enemyHealth.SetHealth(_config.Health);
            if (player.TryGetComponent(out ISpeedChangeable speed))
                speed.SetSpeed(_config.Speed);
            
            return player;
        }
    }

public interface IPlayerFactory
    {
        Player CreatePlayer(Vector3 position, Transform parent);
    }
}