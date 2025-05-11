using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class TriggerCollider : MonoBehaviour
    {
        private IEntity _entity; 
        private void OnTriggerEnter(Collider other)
        {
            _entity = gameObject.GetComponent<IEntity>();
            if (other.TryGetComponent(out IEntity collidedEntity))
            {
                if (collidedEntity.TryGetTakeDamage(out var damageable))
                {
                    Debug.Log("collidedEntity takes damage");
                    damageable.Invoke(_entity.GetBaseDamage().Value);
                    _entity.GetDealDamageEvent().Invoke();
                }
            }
                
            
        }
    }
}
