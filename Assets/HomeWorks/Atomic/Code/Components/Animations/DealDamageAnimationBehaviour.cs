using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class DealDamageAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int DealDamage = Animator.StringToHash("DealDamage");
        
        private Animator _animator;
        private AnimationEventDispatcher _animationEventDispatcher;
        
        private IEvent _dealDamageRequest;
        private IEvent _dealDamageAction;

        public void Init(IEntity entity)
        {
            _dealDamageRequest = entity.GetDealDamageReqest();
            _dealDamageRequest.Subscribe(OnShootRequest);

            _dealDamageAction = entity.GetDealDamageAction();
            _animator = entity.GetAnimator();

            _animationEventDispatcher = entity.GetAnimationEventDispatcher();
            _animationEventDispatcher.OnEventReceived += OnAnimationEventReceived;
        }

        private void OnShootRequest()
        {
            _animator.SetTrigger(DealDamage);
            Debug.Log("Хочу пульнуть пулькой");
        }

        private void OnAnimationEventReceived(string eventName)
        {
            if (eventName == "DealDamage")
            {
                Debug.Log("Поднял пестик и прицелился");
                _dealDamageAction?.Invoke();
            }
        }

        public void Dispose(IEntity entity)
        {
            _dealDamageRequest.Unsubscribe(OnShootRequest);
            _animationEventDispatcher.OnEventReceived -= OnAnimationEventReceived;
        }
    }
}