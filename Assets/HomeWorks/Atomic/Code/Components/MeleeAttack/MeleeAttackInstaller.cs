using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class MeleeAttackInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveFloat _meleeBaseDamage;
        [SerializeField] private ReactiveFloat _reloadInterval;

        public void Install(IEntity entity)
        {
            entity.AddBaseDamage(_meleeBaseDamage);
            entity.AddRealoadInterval(_reloadInterval);

            entity.AddBehaviour(new MeleeAttackBehaviour());
        }
    }
}