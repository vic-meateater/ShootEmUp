using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class RotationBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IReactiveVariable<Vector3> _lookPoint;
        private Transform _transform;
        private Rigidbody _rb;
        private IReactiveVariable<float> _rotationSpeed;
        private ReactiveBool _isDead;

        public void Init(IEntity entity)
        {
            _transform = entity.GetTransform();
            _lookPoint = entity.GetLookPoint();
            _rb = entity.GetRigidbody();
            _rotationSpeed = entity.GetRotationSpeed();
            _isDead = entity.GetIsDead();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if(!_isDead.Value)
                RotateBody(deltaTime);
        }

        private void RotateBody(float deltaTime)
        {
            Vector3 direction = (_lookPoint.Value - _transform.position);
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                _rb.MoveRotation(Quaternion.Slerp(
                    _rb.rotation, 
                    targetRotation, 
                    _rotationSpeed.Value * deltaTime));
            }
        }
    }
}