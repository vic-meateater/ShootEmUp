using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class CharacterAnimationBehaviour : IEntityInit
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        private ReactiveBool _isMoving;
        private Animator _animator;
        
        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _isMoving = entity.GetIsMoving();
            _isMoving.Subscribe(OnIsMovingAction);
        }

        private void OnIsMovingAction(bool isMoving)
        {
            _animator.SetBool(IsMoving, isMoving);
        }
    }
}