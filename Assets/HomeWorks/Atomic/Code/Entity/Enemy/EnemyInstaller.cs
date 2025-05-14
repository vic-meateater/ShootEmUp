using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class EnemyInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddSpawnedEvent(new Event<IEntity>());
            entity.AddParentPosition(new ReactiveVector3(Vector3.zero));
            entity.AddAtomicTimer(new Timer());
            
            entity.AddBehaviour(new EnemyMoveBehaviour());
            entity.AddBehaviour(new EnemyAttackBehaviour());
        }
    }
}