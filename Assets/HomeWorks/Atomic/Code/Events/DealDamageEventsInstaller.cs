using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class DealDamageEventsInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddDealDamageReqest(new Event());
            entity.AddDealDamageAction(new Event());
            entity.AddDealDamageEvent(new Event());
        }
    }
}