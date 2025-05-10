using System;
using Atomic.Contexts;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class WeaponContextInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            //context.AddSystem(new WeaponController());
            context.AddSystem(new WeaponSpawnerController());
        }
    }

    public class WeaponSpawnerController : IContextInit
    {
        private PlayerService _playerService;
        private WeaponService _weaponService;
        private GameObjectSpawner _spawner;
        
        public void Init(IContext context)
        {
            _spawner = context.GetGameObjectSpawner();
            _playerService = context.GetGameServices().PlayerService;
            _weaponService = context.GetGameServices().WeaponService;
            
            var weaponSlot = _playerService.Player.GetWeaponSlot();
            
            _spawner.SpawnGameObject(_weaponService.WeaponConfig.Prefab, weaponSlot, weaponSlot);
            _weaponService.SetWeaponEntity(_spawner.SpawnedGO.GetComponent<SceneEntity>());
        }
    }
}