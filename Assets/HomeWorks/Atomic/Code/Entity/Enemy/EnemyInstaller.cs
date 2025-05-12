using System;
using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class EnemyInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddSpawnedEvent(new Event<IEntity>());

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