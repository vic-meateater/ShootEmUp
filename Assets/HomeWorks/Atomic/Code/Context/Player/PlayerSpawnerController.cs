using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawnerController : IContextInit
    {
        private PlayerSpawner _playerSpawner;
        private PlayerService _playerService;
        private Transform _weaponSlot;

        public void Init(IContext context)
        {
            _playerSpawner = context.GetPlayerSpawner();
            _playerService = context.GetGameServices().PlayerService;
            
            _playerSpawner.SpawnPlayer(_playerService.PlayerConfig.Prefab);
            _playerService.SetPlayerEntity(_playerSpawner.PlayerGO.GetComponent<SceneEntity>());
            _playerService.Player.AddPlayerTag();
        }
    }
}