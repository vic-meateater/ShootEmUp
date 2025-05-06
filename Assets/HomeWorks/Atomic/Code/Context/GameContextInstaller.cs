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

        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            context.AddPlayerService(_playerService);
            
            context.AddSystem(_playerInputController);
        }
    }

    [Serializable]
    public class PlayerInputController : IContextInit
    {
        private MoveController _moveController;
        private PlayerService _playerService;
        private SceneEntity _playerEnt;
        private IReactiveVariable<Vector3> _movedirection;
        private ReactiveVector3 _lookPoint;
        private ReactiveBool _isShooting;


        public void Init(IContext context)
        {
            _moveController = context.GetMoveController();
            _playerService = context.GetPlayerService();
            _movedirection = _moveController.MoveDirection;
            _movedirection.Subscribe(OnMoveChange);

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