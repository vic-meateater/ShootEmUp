using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class RotationInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<float> _rotationSpeed;
        public void Install(IEntity entity)
        {
            entity.AddLookPoint(new ReactiveVariable<Vector3>());
            entity.AddRotationSpeed(_rotationSpeed);

            entity.AddBehaviour(new RotationBehaviour());
        }
    }
}