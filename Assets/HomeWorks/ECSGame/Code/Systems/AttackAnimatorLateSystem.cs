using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class AttackAnimatorLateSystem : ILateSystem
    {
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        public World World { get; set; }

        private Filter _filter;
        private Stash<AnimatorView> _animatorViewStash;
        private Event<FireEvent> _fireEvent;

        public void OnAwake()
        {
            _filter = World.Filter.With<AnimatorView>().Build();
            _animatorViewStash = World.GetStash<AnimatorView>();
            _fireEvent = World.GetEvent<FireEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var @event in _fireEvent.publishedChanges)
            {
                ref var animator = ref _animatorViewStash.Get(@event.Entity);
                animator.Value.SetTrigger(AttackTrigger);
            }
        }

        public void Dispose()
        {
        }
    }
}