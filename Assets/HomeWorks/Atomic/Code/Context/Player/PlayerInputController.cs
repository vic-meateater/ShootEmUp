using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
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
            _playerService = context.GetGameServices().PlayerService;
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
                _playerService.Player.GetDealDamageEvent().Invoke();
            }
        }

        private void OnLookPointChange(Vector3 lookPoint)
        {
            _playerService.Player.GetLookPoint().Value = lookPoint;
        }

        private void OnMoveChange(Vector3 direction)
        {
            _playerService.Player.GetMoveDirection().Value = direction;
        }
    }
}