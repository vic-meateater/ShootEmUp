using Atomic.Contexts;
using Atomic.Elements;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class WeaponController : IContextInit, IContextDispose
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

        public void Dispose(IContext context)
        {
            _shootEvent.OnEvent -= _bulletsService.OnShootEvent;
        }
    }
}