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

            entity.AddBehaviour(new EnemyBehaviour());
            entity.AddBehaviour(new EnemyAttackBehaviour());
        }
    }

    public class EnemyAttackBehaviour : IEntityInit
    {
        private IEvent _dealDamageRequset;

        public void Init(IEntity entity)
        {
            _dealDamageRequset = entity.GetDealDamageReqest();
            _dealDamageRequset.Subscribe(OnDealDamageRequestAction);
        }

        private void OnDealDamageRequestAction()
        {
            Debug.Log("Zobie attack");
        }
    }
}