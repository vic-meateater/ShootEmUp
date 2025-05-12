using System;
using System.Numerics;
using Atomic.Elements;
using Atomic.Entities;
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

            entity.AddBehaviour(new EnemyBehaviour());
        }
    }

    public class EnemyAttackBehaviour : IEntityInit
    {
        public void Init(IEntity entity)
        {
            
        }
    }
}