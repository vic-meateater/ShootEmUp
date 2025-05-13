using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class MеleeTriggerCollider : MonoBehaviour
    {
        private IEvent _damageableEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (gameObject.TryGetEntity(out IEntity entity) &&
                other.TryGetComponent(out IEntity collidedEntity))
            {
                if (entity.HasEnemyTag() && collidedEntity.HasPlayerTag())
                {
                    DealDamage(entity, collidedEntity);
                }
            }
        }

        private void DealDamage(IEntity source, IEntity target)
        {
            if (target.TryGetTakeDamage(out var damageable))
            {
                source.GetDealDamageEvent().OnEvent += () => DealDamageEventAction(source, target);
                source.GetDealDamageReqest()?.Invoke();
            }
        }

        private void DealDamageEventAction(IEntity source, IEntity target)
        {
            target.GetTakeDamage().Invoke(source.GetBaseDamage().Value);
        }
    }
}