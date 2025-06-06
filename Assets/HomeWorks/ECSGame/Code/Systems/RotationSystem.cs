using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class RotationSystem : ISystem
    {
        public World World { get; set; }
        
        private Filter _filter;
        private Stash<MoveDirection> _directionStash;
        private Stash<Rotation> _rotationStash;

        public void OnAwake()
        {
            _filter = World.Filter.With<MoveDirection>().With<Rotation>().Build();
            _directionStash = World.GetStash<MoveDirection>();
            _rotationStash = World.GetStash<Rotation>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter) 
            {
                var direction = _directionStash.Get(entity).Value;
                if (direction != Vector3.zero) 
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    _rotationStash.Set(entity, new Rotation { Value = targetRotation });
                }
            }
        }

        public void Dispose()
        {

        }
    }
}