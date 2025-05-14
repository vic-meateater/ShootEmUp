using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class MoveBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private Rigidbody _rb;
        private IReactiveVariable<float> _moveSpeed;
        private IReactiveVariable<Vector3> _direction;
        private ReactiveVector3 _position;
        private ReactiveBool _isMoving;
        private ReactiveBool _isDead;

        public void Init(IEntity entity)
        {
            _rb = entity.GetRigidbody();
            _moveSpeed = entity.GetMoveSpeed();
            _direction = entity.GetMoveDirection();
            _position = entity.GetMovePosition();
            _isMoving = entity.GetIsMoving();
            _rb.freezeRotation = true;
            _position.Value =  _rb.position;
            _isDead = entity.GetIsDead();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if (!_isDead.Value)
            {
                Move(deltaTime);
            }
            else
            {
                _direction.Value = Vector3.zero;
            }
            _isMoving.Value = _direction.Value.sqrMagnitude > 0;
        }
        
        private void Move(float deltaTime)
        {
            Vector3 newPosition = _rb.position + _direction.Value * _moveSpeed.Value * deltaTime;
            _position.Value = newPosition;
            _rb.MovePosition(newPosition);
        }
    }
}