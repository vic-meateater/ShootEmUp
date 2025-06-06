using Scellecs.Morpeh;
using ShootEmUp.Homeworks.ECSGame;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public sealed class DeathAnimatorLateSystem : ILateSystem 
{
    private static readonly int IsDeath = Animator.StringToHash("IsDeath");
    public World World { get; set;}
    
    private Stash<AnimatorView> _animatorViewStash;
    private Stash<ReadyToClean> _readyToCleanStash;
    private Stash<IsDeath> _isDeathStash;
    
    private Event<DeathEvent> _deathEvent;

    public void OnAwake() 
    {
        _animatorViewStash = World.GetStash<AnimatorView>();
        _readyToCleanStash = World.GetStash<ReadyToClean>();
        _isDeathStash = World.GetStash<IsDeath>();
        
        _deathEvent = World.GetEvent<DeathEvent>();
    }

    public void OnUpdate(float deltaTime) 
    {
        foreach (var @event in _deathEvent.publishedChanges)
        {
            if (_animatorViewStash.Has(@event.Entity) && _isDeathStash.Has(@event.Entity))
            {
                var animator = _animatorViewStash.Get(@event.Entity);
                var isDeath = _isDeathStash.Has(@event.Entity);
                animator.Value.SetBool(IsDeath, isDeath);
            }
            else
            {
                _readyToCleanStash.Add(@event.Entity);
            }
        }
    }

    public void Dispose()
    {

    }
}