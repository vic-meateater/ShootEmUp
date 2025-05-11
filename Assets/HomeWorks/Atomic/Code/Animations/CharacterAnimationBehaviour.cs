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

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _isMoving = entity.GetIsMoving();
            _isMoving.Subscribe(OnIsMovingAction);

            _isDead = entity.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);
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