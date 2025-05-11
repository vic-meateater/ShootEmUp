using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class BulletInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveFloat _baseDamage;
        public void Install(IEntity entity)
        {
            entity.AddBehaviour(new BulletBehaviour());
            entity.AddDealDamageEvent(new Event());
            entity.AddBaseDamage(_baseDamage);
        }
    }
}