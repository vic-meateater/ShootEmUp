using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIViewController : IContextInit, IContextDispose
    {
        private IUIViewModel _viewModel;
        private PlayerService _playerService;
        private IReactiveVariable<float> _currentHealth;
        private IReactiveVariable<bool> _isDead;

        public void Init(IContext context)
        {
            _viewModel = context.GetIUIViewModel();
            _playerService = context.GetGameServices().PlayerService;
    
            _currentHealth= _playerService.Player.GetCurrentHealth();
            _viewModel.CurrentHealth.Value = _currentHealth.Value;
            _currentHealth.Subscribe(OnHealthChanged);
            
            _isDead = _playerService.Player.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);
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