using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class CharacterAnimationBehaviour : IEntityInit
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        
        private ReactiveBool _isMoving;
        private Animator _animator;
        private IReactiveVariable<bool> _isDead;
        private AnimationEventDispatcher _dispatcher;
        private IEvent _isDeadEvent;

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _isMoving = entity.GetIsMoving();
            _isMoving.Subscribe(OnIsMovingAction);

            _isDead = entity.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);
            
            _dispatcher = entity.GetAnimationEventDispatcher();
            _dispatcher.OnEventReceived += OnAnimationEventReceived;

            _isDeadEvent = entity.GetCharacterDieEvent();
        }

        private void OnAnimationEventReceived(string animationEvent)
        {
            if (animationEvent == "Dead")
            {
                _isDeadEvent.Invoke();
            }
        }

        private void OnIsDeadAction(bool isDead)
        {
            _animator.SetBool(IsDead, isDead);
        }

        private void OnIsMovingAction(bool isMoving)
        {
            _animator.SetBool(IsMoving, isMoving);
        }
    }
}