using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class MovementSystem : ISystem
    {
        public World World { get; set; }
        private Filter _filter;

        private Stash<MoveDirection> _moveDirectionStash;
        private Stash<MoveSpeed> _moveSpeedStash;
        private Stash<Position> _positionStash;
        private Stash<Rotation> _rotationStash;
        
        private Event<MoveEvent> _moveEvent;


        public void OnAwake()
        {
            _filter = World.Filter
                .With<WantsToMove>()
                .With<MoveDirection>()
                .With<MoveSpeed>()
                .With<Position>()
                .Without<IsDeath>()
                .Build();
            
            _moveDirectionStash = World.GetStash<MoveDirection>();
            _moveSpeedStash = World.GetStash<MoveSpeed>();
            _positionStash = World.GetStash<Position>();
            _rotationStash = World.GetStash<Rotation>();
            
            _moveEvent = World.GetEvent<MoveEvent>(); 
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                MoveDirection direction = _moveDirectionStash.Get(entity);
                bool shouldMove = direction.Value.sqrMagnitude > 0.01f;

                
                MoveSpeed moveSpeed = _moveSpeedStash.Get(entity);
                ref Position position =  ref _positionStash.Get(entity);

                Vector3 forward = direction.Value;

                if (_rotationStash.Has(entity))
                {
                    var rotation = _rotationStash.Get(entity).Value;
                    forward = rotation * Vector3.forward;
                }
                
                position.Value += forward.normalized * (moveSpeed.Value * deltaTime);
                bool isMoving = direction.Value.sqrMagnitude > 0.01f;
                _moveEvent.NextFrame(new MoveEvent {IsMoving = isMoving, Entity = entity});
            }
        }

        public void Dispose()
        {
        }
    }
}