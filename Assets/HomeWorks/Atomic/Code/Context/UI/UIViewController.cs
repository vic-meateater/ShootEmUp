using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIViewController : IContextInit, IContextDispose
    {
        private IUIViewModel _viewModel;
        private PlayerService _playerService;
        private WeaponService _weaponService;
        private IReactiveVariable<float> _currentHealth;
        private IReactiveVariable<bool> _isDead;
        private IReactiveVariable<int> _maxBullets;
        private IReactiveVariable<int> _currentBullets;

        public void Init(IContext context)
        {
            _viewModel = context.GetIUIViewModel();
            _playerService = context.GetGameServices().PlayerService;
            _weaponService = context.GetGameServices().WeaponService;
            
            _currentHealth= _playerService.Player.GetCurrentHealth();
            _viewModel.CurrentHealth.Value = _currentHealth.Value;
            _currentHealth.Subscribe(OnHealthChanged);
            
            _isDead = _playerService.Player.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);

            _maxBullets = _weaponService.Weapon.GetMaxBullets();
            _viewModel.MaxBullets.Value = _maxBullets.Value;
            _maxBullets.Subscribe(OnMaxBulletsChanged);
            
            _currentBullets = _weaponService.Weapon.GetCurrentBullets();
            _viewModel.CurrentBullets.Value = _currentBullets.Value;
            _currentBullets.Subscribe(OnCurrentBulletsChanged);
        }

        private void OnCurrentBulletsChanged(int currentBullets)
        {
            _viewModel.CurrentBullets.Value = currentBullets;
        }

        private void OnMaxBulletsChanged(int maxBullets)
        {
            _viewModel.MaxBullets.Value = maxBullets;
        }

        private void OnIsDeadAction(bool isDead)
        {
            _viewModel.IsDead.Value = isDead;
        }

        private void OnHealthChanged(float health)
        {
            _viewModel.CurrentHealth.Value = health;
        }

        public void Dispose(IContext context)
        {
            _currentHealth.Unsubscribe(OnHealthChanged);
            _isDead.Unsubscribe(OnIsDeadAction);
        }
    }
}