using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class HealthInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<float> _healthPoints;
        public void Install(IEntity entity)
        {
            entity.AddCurrentHealth(_healthPoints);
            entity.AddIsDead(new ReactiveVariable<bool>(false));
            entity.AddTakeDamage(new Event<float>());
            
            entity.AddBehaviour(new HealthBehaviour());
        }
    }
}