using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class DamageAnimatorLateSystem : ILateSystem
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        public World World { get; set; }
        
        private Stash<AnimatorView> _animatorViewStash;
        private Event<DamageEvent> _damageEvent;

        public void OnAwake()
        {
            _animatorViewStash = World.GetStash<AnimatorView>();
            _damageEvent = World.GetEvent<DamageEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var @event in _damageEvent.publishedChanges)
            {
                if (_animatorViewStash.Has(@event.Entity))
                {
                    var animator = _animatorViewStash.Get(@event.Entity);
                    animator.Value.SetTrigger(TakeDamage);
                    //добавить готовность к атаке (таг готов атаковать)
                }
            }
        }

        public void Dispose()
        {

        }
    }
}