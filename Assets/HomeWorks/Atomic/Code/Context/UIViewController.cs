using Atomic.Contexts;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIViewController : IContextInit
    {
        private IUIViewModel _viewModel;
        private PlayerService _playerService;
         
        public void Init(IContext context)
        {
            _viewModel = context.GetIUIViewModel();
            _playerService = context.GetPlayerService();
    
            var currentHealth= _playerService.PlayerEntity.GetCurrentHealth();
            _viewModel.CurrentHealth.Value = currentHealth.Value;
            currentHealth.Subscribe(OnHealthChanged);
        }
    
        private void OnHealthChanged(float health)
        {
            _viewModel.CurrentHealth.Value = health;
        }
    }
}