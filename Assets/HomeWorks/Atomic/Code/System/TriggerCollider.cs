using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class TriggerCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (gameObject.TryGetEntity(out IEntity entity) &&
                other.TryGetComponent(out IEntity collidedEntity))
            {
                // Случай, когда игрок атакует врага
                if (entity.HasPlayerTag() && collidedEntity.HasEnemyTag())
                {
                    other.enabled = false;
                    DealDamage(entity, collidedEntity);
                }
                // Случай, когда враг атакует игрока
                else if (entity.HasEnemyTag() && collidedEntity.HasPlayerTag())
                {
                    DealDamage(entity, collidedEntity);
                }
            }
        }

        private void DealDamage(IEntity source, IEntity target)
        {
            if (target.TryGetTakeDamage(out var damageable))
            {
                damageable.Invoke(source.GetBaseDamage().Value);
                source.GetDealDamageEvent()?.Invoke();
            }
        }
    }
    //     private IEntity _entity;
    //
    //     private void OnTriggerEnter(Collider other)
    //     {
    //         if (gameObject.TryGetEntity(out IEntity entity) && other.TryGetComponent(out IEntity collidedEntity))
    //         {
    //             if (entity.HasPlayerTag() && collidedEntity.HasEnemyTag())
    //             {
    //                 other.enabled = false;
    //                 if (collidedEntity.TryGetTakeDamage(out var damageable))
    //                 {
    //                     damageable.Invoke(entity.GetBaseDamage().Value);
    //                     entity.GetDealDamageEvent()?.Invoke();
    //                 }
    //             }
    //         }
    //     }
    // }
    //
    // public class ZombieTriggerEnter : MonoBehaviour
    // {
    //     private IEntity _entity;
    //
    //     private void OnTriggerEnter(Collider other)
    //     {
    //         if (gameObject.TryGetEntity(out IEntity entity) && other.TryGetComponent(out IEntity collidedEntity))
    //         {
    //             if (entity.HasEnemyTag() && collidedEntity.HasPlayerTag())
    //             {
    //                 if (collidedEntity.TryGetTakeDamage(out var damageable))
    //                 {
    //                     damageable.Invoke(entity.GetBaseDamage().Value);
    //                     entity.GetDealDamageEvent()?.Invoke();
    //                 }
    //             }
    //         }
    //     }
    // }
}