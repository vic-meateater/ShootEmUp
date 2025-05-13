using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class MeleeAttackInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveFloat _meleeBaseDamage;

        public void Install(IEntity entity)
        {
            entity.AddDealDamageAction(new Event());
            entity.AddBaseDamage(_meleeBaseDamage);

            entity.AddBehaviour(new MeleeAttackBehaviour());
        }
    }

    public class MeleeAttackBehaviour : IEntityInit, IEntityUpdate
    {
        private IEvent _dealDamageEvent;
        private IEvent _dealDamageRequest;
        private Timer _timer;
        private IEntity _entity;
        private ReactiveFloat _baseDamage;
        private ReactiveInt _currentTarget;
        private IEntity _target;
        private EntityWorld _entityWorld;

        public void Init(IEntity entity)
        {
            _baseDamage = entity.GetBaseDamage();
            _dealDamageEvent = entity.GetDealDamageEvent();
            _dealDamageEvent.Subscribe(OnDealDamageEventAction);

            _dealDamageRequest = entity.GetDealDamageReqest();

            _timer = entity.GetAtomicTimer();
            _timer.SetDuration(2f);
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
    }
}