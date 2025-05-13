using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class EnemyAttackBehaviour : IEntityInit
    {
        private IEvent _meleeAttackEvent;
        private IEvent _dealDamageAction;

        public void Init(IEntity entity)
        {
            _meleeAttackEvent = entity.GetDealDamageEvent();

            _dealDamageAction = entity.GetDealDamageAction();
            _dealDamageAction.Subscribe(OnDealDamageActionReact);
        }

        private void OnDealDamageActionReact()
        {
            _meleeAttackEvent?.Invoke();
        }
    }
}