using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class AnimatorInstaller : IEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationEventDispatcher _eventDispatcher;

        public void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddBehaviour(new CharacterAnimationBehaviour());
            entity.AddBehaviour(new DealDamageAnimationBehaviour());

            entity.AddAnimationEventDispatcher(_eventDispatcher);
        }
    }
}