using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class EnemyBehaviour : IEntityInit
    {
        private IEvent _isDeadEvent;
        private float _respawnTimer;
        private IReactiveVariable<bool> _isDead;
        private IReactiveVariable<Vector3> _moveDirection;
        private IEvent<IEntity> _spawnedEvent;
        private ReactiveVector3 _movePosition;
        private IReactiveVariable<float> _moveSpeed;
        private IReactiveVariable<Vector3> _lookPoint;

        public void Init(IEntity entity)
        {
            
            _moveDirection = entity.GetMoveDirection();
            _movePosition = entity.GetMovePosition();
            _moveSpeed = entity.GetMoveSpeed();
            _lookPoint = entity.GetLookPoint();

            _isDeadEvent = entity.GetCharacterDieEvent();
            _isDeadEvent.Subscribe(OnIsDeadEventAction);

            
            _isDead = entity.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);
            
            _spawnedEvent = entity.GetSpawnedEvent();
            _spawnedEvent.Subscribe(OnSpawnedAction);
        }


        private void OnSpawnedAction(IEntity playerEntity)
        {
            PlayerPositionChanged(playerEntity.GetMovePosition().Value);
            playerEntity.GetMovePosition().OnValueChanged += PlayerPositionChanged;
        }

        private void PlayerPositionChanged(Vector3 playerPosition)
        {
            if (!_isDead.Value)
            {
                var direction = (playerPosition - _movePosition.Value).normalized;
                _moveDirection.Value = direction;
                _lookPoint.Value = playerPosition;
            }
        }

        private void OnIsDeadAction(bool isDead)
        {
            _moveSpeed.Value = 0;
            _moveDirection.Value = Vector3.zero;
        }

        private void OnIsDeadEventAction()
        {
            _isDead.Value = false;
        }
    }
}