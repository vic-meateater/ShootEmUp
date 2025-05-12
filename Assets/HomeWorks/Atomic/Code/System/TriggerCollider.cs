using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class TriggerCollider : MonoBehaviour
    {
        private IEntity _entity; 
        private void OnTriggerEnter(Collider other)
        {
            other.enabled = false;
            if(gameObject.TryGetEntity(out IEntity entity))
            {
                if (other.TryGetComponent(out IEntity collidedEntity))
                {
                    if (collidedEntity.TryGetTakeDamage(out var damageable))
                    {
                        Debug.Log("collidedEntity takes damage");
                        damageable.Invoke(entity.GetBaseDamage().Value);
                        entity.GetDealDamageEvent()?.Invoke();
                    }
                }
            }
                
            
        }
    }
}
