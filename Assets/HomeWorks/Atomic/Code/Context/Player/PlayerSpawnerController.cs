using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawnerController : IContextInit
    {
        private PlayerSpawner _playerSpawner;
        private PlayerService _playerService;
        private WeaponService _weaponService;
        private GameObjectSpawner _spawner;
        private Transform _weaponSlot;

        public void Init(IContext context)
        {
            _playerSpawner = context.GetPlayerSpawner();
            _playerService = context.GetGameServices().PlayerService;
            _weaponService = context.GetGameServices().WeaponService;
            _spawner = context.GetGameObjectSpawner();
            
            _playerSpawner.SpawnPlayer(_playerService.PlayerConfig.Prefab);
            _playerService.SetPlayerEntity(_playerSpawner.PlayerGO.GetComponent<SceneEntity>());
            _weaponSlot = _playerService.Player.GetWeaponSlot();
            
            _spawner.SpawnGameObject(_weaponService.WeaponConfig.Prefab, _weaponSlot, _weaponSlot);
            _weaponService.SetWeaponEntity(_spawner.SpawnedGO.GetComponent<SceneEntity>());
        }
    }
}