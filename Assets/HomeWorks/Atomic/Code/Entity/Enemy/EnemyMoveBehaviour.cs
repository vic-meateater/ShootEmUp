using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class EnemyMoveBehaviour : IEntityInit, IEntityUpdate, IEntityDispose
    {
        private const float STOP_DISTANCE = 1.5f;
        
        private IEvent _isDeadAnimatorEvent;
        private float _respawnTimer;
        private IReactiveVariable<bool> _isDead;
        private IReactiveVariable<Vector3> _moveDirection;
        private IEvent<IEntity> _spawnedEvent;
        private ReactiveVector3 _movePosition;
        private IReactiveVariable<bool> _isMoving;
        private IReactiveVariable<Vector3> _lookPoint;
        private IEntity _playerEntity;
        private IReactiveVariable<Vector3> _playerPositionReactive;
        private float _distanceToPlayer;
        private IEvent _dealDamageRequest;

        public void Init(IEntity entity)
        {
            _moveDirection = entity.GetMoveDirection();
            _movePosition = entity.GetMovePosition();
            _isMoving = entity.GetIsMoving();
            _lookPoint = entity.GetLookPoint();

            _isDeadAnimatorEvent = entity.GetCharacterDieEvent();
            _isDeadAnimatorEvent.Subscribe(OnIsDeadAnimatorEventAction);


            _isDead = entity.GetIsDead();
            
            _spawnedEvent = entity.GetSpawnedEvent();
            _spawnedEvent.Subscribe(OnSpawnedAction);

            _dealDamageRequest = entity.GetDealDamageReqest();
            _dealDamageRequest.Subscribe(OnDealDamageRequestAction);
        }

        private void OnDealDamageRequestAction()
        {
            _moveDirection.Value = Vector3.zero;
            _isMoving.Value = false;
        }


        private void OnSpawnedAction(IEntity playerEntity)
        {
            _playerEntity = playerEntity;
            _playerPositionReactive = _playerEntity.GetMovePosition();
            _playerPositionReactive.Subscribe(PlayerPositionChanged);
        }

        private void PlayerPositionChanged(Vector3 playerPosition)
        {
            if (_isDead.Value)
                return;

            _distanceToPlayer = Vector3.Distance(_movePosition.Value, playerPosition);
            
            if (_distanceToPlayer > STOP_DISTANCE)
            {
                var direction = (playerPosition - _movePosition.Value).normalized;
                _moveDirection.Value = direction;
                _lookPoint.Value = playerPosition;
            }
        }

        private void OnIsDeadAnimatorEventAction()
        {
            _isDead.Value = false;
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_playerEntity == null || _playerPositionReactive == null)
                return;

            PlayerPositionChanged(_playerEntity.GetMovePosition().Value);
        }

        public void Dispose(IEntity entity)
        {
            _isDeadAnimatorEvent.Unsubscribe(OnIsDeadAnimatorEventAction);
            _spawnedEvent.Unsubscribe(OnSpawnedAction);
            _dealDamageRequest.Unsubscribe(OnDealDamageRequestAction);
            _playerPositionReactive.Unsubscribe(PlayerPositionChanged);
        }
    }
}