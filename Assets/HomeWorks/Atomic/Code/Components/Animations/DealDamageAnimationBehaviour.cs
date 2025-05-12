using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class DealDamageAnimationBehaviour : IEntityInit
    {
        private static readonly int DealDamage = Animator.StringToHash("DealDamage");
        
        private Animator _animator;
        private AnimationEventDispatcher _animationEventDispatcher;
        
        private IEvent _shootRequest;
        private IEvent _shootAction;

        public void Init(IEntity entity)
        {
            _shootRequest = entity.GetDealDamageReqest();
            _shootRequest.Subscribe(OnShootRequest);

            _shootAction = entity.GetDealDamageAction();
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
                _shootAction?.Invoke();
            }
        }
    }
}