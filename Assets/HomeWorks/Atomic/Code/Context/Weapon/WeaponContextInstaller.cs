using System;
using Atomic.Contexts;
using Atomic.Elements;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class WeaponContextInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new WeaponSpawnerController());
            context.AddSystem(new WeaponController());
        }
    }

    public class WeaponController : IContextInit
    {
        private WeaponService _weaponService;
        private BulletsService _bulletsService;
        private IEvent _shootEvent;
        public void Init(IContext context)
        {
            _weaponService = context.GetGameServices().WeaponService;
            _bulletsService = context.GetGameServices().BulletsService;
            _shootEvent = _weaponService.Weapon.GetDealDamageEvent();
            _shootEvent.OnEvent += _bulletsService.OnShootEvent;
        }
    }
}