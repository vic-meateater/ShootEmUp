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
        private WeaponService _weaponService;
        private IReactiveVariable<Vector3> _moveDirection;
        private ReactiveVector3 _lookPoint;
        private ReactiveBool _isShooting;
        private IEvent _damageAction;


        public void Init(IContext context)
        {
            _playerService = context.GetGameServices().PlayerService;
            _weaponService = context.GetGameServices().WeaponService;
            
            _moveController = context.GetMoveController();
            _moveDirection = _moveController.MoveDirection;
            _moveDirection.Subscribe(OnMoveChange);

            _lookPoint = _moveController.LookPoint;
            _lookPoint.Subscribe(OnLookPointChange);

            _isShooting = _moveController.IsShooting;
            _isShooting.Subscribe(ShootingRequestAction);

            _damageAction = _playerService.Player.GetDealDamageAction();
            _damageAction.Subscribe(OnDealDamageAction);
        }

        private void OnDealDamageAction()
        {
            Debug.Log("weapn DealDamageAction context");
            _weaponService.Weapon.GetDealDamageAction()?.Invoke();
        }

        private void ShootingRequestAction(bool isShooting)
        {
            if (isShooting)
            {
                Debug.Log("Context IsShooting");
                _playerService.Player.GetDealDamageReqest()?.Invoke();
            }
        }

        private void OnLookPointChange(Vector3 lookPoint)
        {
            _playerService.Player.GetLookPoint().Value = lookPoint;
        }

        private void OnMoveChange(Vector3 direction)
        {
            _playerService.Player.GetMoveDirection().Value = direction;
            _playerService.Player.GetIsMoving().Value = direction.sqrMagnitude > 0;

        }
    }
}