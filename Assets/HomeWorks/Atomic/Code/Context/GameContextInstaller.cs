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
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private PlayerService _playerService;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private UIViewInstaller _uiViewInstaller;
        

        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            context.AddPlayerSpawner(_playerSpawner);
            context.AddPlayerService(_playerService);
            context.AddPlayerConfig(_playerConfig);

            context.AddSystem(new PlayerSpawnerController());
            _uiViewInstaller.Install(context);
            context.AddSystem(new UIViewController());
            context.AddSystem(_playerInputController);
        }
    }
    
    public class PlayerSpawnerController : IContextInit
    {
        private PlayerConfig _playerConfig;
        private PlayerSpawner _playerSpawner;
        private PlayerService _playerService;
        
        public void Init(IContext context)
        {
            _playerConfig = context.GetPlayerConfig();
            _playerSpawner = context.GetPlayerSpawner();
            _playerService = context.GetPlayerService();
            
            _playerSpawner.SpawnPlayer(_playerConfig.Prefab);
            _playerService.SetPlayerEntity(_playerSpawner.PlayerGO.GetComponent<SceneEntity>());
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