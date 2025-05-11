using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class MoveInstaller : IEntityInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private ReactiveVariable<float> _moveSpeed;
        
        public void Install(IEntity entity)
        {
            entity.AddRigidbody(_rigidbody);
            entity.AddTransform(_transform);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddMoveDirection(new ReactiveVariable<Vector3>());
            entity.AddIsMoving(new ReactiveBool());
            entity.AddMovePosition(new ReactiveVector3());

            entity.AddBehaviour(new MoveBehaviour());
        }
    }
}