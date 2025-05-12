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
        [SerializeField] private ReactiveBool _isDead;
        public void Install(IEntity entity)
        {
            entity.AddCurrentHealth(_healthPoints);
            entity.AddIsDead(_isDead);
            entity.AddTakeDamage(new Event<float>());
            
            entity.AddBehaviour(new HealthBehaviour());
        }
    }
}