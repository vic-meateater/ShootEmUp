using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class MeleeAttackBehaviour : IEntityInit, IEntityUpdate, IEntityDispose
    {
        private IEvent _dealDamageEvent;
        private IEvent _dealDamageRequest;
        private Timer _timer;
        private ReactiveFloat _reloadInterval;

        public void Init(IEntity entity)
        {
            _reloadInterval = entity.GetRealoadInterval();
            _dealDamageEvent = entity.GetDealDamageEvent();
            _dealDamageEvent.Subscribe(OnDealDamageEventAction);

            _dealDamageRequest = entity.GetDealDamageReqest();

            _timer = entity.GetAtomicTimer();
            _timer.SetDuration(_reloadInterval.Value);
            _timer.OnEnded += DealDamageRequest;
        }

        private void DealDamageRequest()
        {
            _dealDamageRequest?.Invoke();
        }

        private void OnDealDamageEventAction()
        {
            _timer.Start();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _timer.Tick(deltaTime);
        }

        public void Dispose(IEntity entity)
        {
            _dealDamageEvent.Unsubscribe(OnDealDamageEventAction);
            _timer.OnEnded -= DealDamageRequest;
        }
    }
}