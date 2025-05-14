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
        private IReactiveVariable<int> _killed;

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

            _killed = _playerService.Player.GetKills();
            _killed.Subscribe(OnKilledChanged);

            _maxBullets = _weaponService.Weapon.GetMaxBullets();
            _viewModel.MaxBullets.Value = _maxBullets.Value;
            _maxBullets.Subscribe(OnMaxBulletsChanged);
            
            _currentBullets = _weaponService.Weapon.GetCurrentBullets();
            _viewModel.CurrentBullets.Value = _currentBullets.Value;
            _currentBullets.Subscribe(OnCurrentBulletsChanged);
            
        }

        private void OnKilledChanged(int kills)
        {
            _viewModel.Kills.Value = kills;
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
            _killed.Unsubscribe(OnKilledChanged);
            _maxBullets.Unsubscribe(OnMaxBulletsChanged);
            _currentBullets.Unsubscribe(OnCurrentBulletsChanged);
        }
    }
}