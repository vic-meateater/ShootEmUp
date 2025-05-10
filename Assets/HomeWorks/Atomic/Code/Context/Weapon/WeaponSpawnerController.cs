using Atomic.Contexts;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
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
            
            var weapon = _spawner.SpawnGameObject(
                _weaponService.WeaponConfig.Prefab, 
                weaponSlot, 
                weaponSlot);
            _weaponService.SetWeaponEntity(weapon.GetComponent<SceneEntity>());
        }
    }
}