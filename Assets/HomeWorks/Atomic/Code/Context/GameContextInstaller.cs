using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;


namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private PlayerService _playerService;
        [SerializeField] private UIView _uiView;
        

        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            context.AddPlayerService(_playerService);
            context.AddIUIViewModel(new UIViewModel(_uiView));

            context.AddSystem(new UIViewController());
            context.AddSystem(_playerInputController);
        }
    }

//    [Serializable]
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
    
     [Serializable]
     public class UIViewInstaller : IContextInstaller
     {
         //переделать через UIViewInstaller in context
         [SerializeField] private UIView _uiView;
         public void Install(IContext context)
         {
             context.AddIUIViewModel(new UIViewModel(_uiView));
    
             context.AddSystem(new UIViewController());
         }
     }

    [Serializable]
    public class PlayerInputController : IContextInit
    {
        private MoveController _moveController;
        private PlayerService _playerService;
        private IReactiveVariable<Vector3> _moveDirection;
        private ReactiveVector3 _lookPoint;
        private ReactiveBool _isShooting;


        public void Init(IContext context)
        {
            _moveController = context.GetMoveController();
            _playerService = context.GetPlayerService();
            _moveDirection = _moveController.MoveDirection;
            _moveDirection.Subscribe(OnMoveChange);

            _lookPoint = _moveController.LookPoint;
            _lookPoint.Subscribe(OnLookPointChange);

            _isShooting = _moveController.IsShooting;
            _isShooting.Subscribe(OnPlayerShooting);
        }

        private void OnPlayerShooting(bool isShooting)
        {
            if (isShooting)
            {
                Debug.Log("Context IsShooting");
                _playerService.PlayerEntity.GetDealDamageEvent().Invoke();
            }
        }

        private void OnLookPointChange(Vector3 lookPoint)
        {
            _playerService.PlayerEntity.GetLookPoint().Value = lookPoint;
        }

        private void OnMoveChange(Vector3 direction)
        {
            _playerService.PlayerEntity.GetMoveDirection().Value = direction;
        }
    }
}