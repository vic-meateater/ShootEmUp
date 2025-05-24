using Scellecs.Morpeh;
using ShootEmUp.Homeworks.ECSGame;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public sealed class AnimatorLateSystem : ILateSystem
{
    private static readonly int _isMovingAnimatorBool = Animator.StringToHash("IsWalking");
    public World World { get; set; }

    private Filter _filter;
    private Stash<AnimatorView> _animatorViewStash;
    private Request<MoveRequest> _moveRequest;

    public void OnAwake()
    {
        _filter = World.Filter.With<AnimatorView>().Build();
        _animatorViewStash = World.GetStash<AnimatorView>();
        _moveRequest = World.GetRequest<MoveRequest>();
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (var request in _moveRequest.Consume())
        {
            foreach (var entity in _filter)
            {
                if (request.Entity == entity)
                {
                    AnimatorView animator = _animatorViewStash.Get(entity);
                    animator.Value.SetBool(_isMovingAnimatorBool, request.IsMoving);
                }
            }
        }
    }

    public void Dispose()
    {
    }
}