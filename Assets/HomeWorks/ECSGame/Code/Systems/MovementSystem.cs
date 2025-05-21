using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

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

        public void OnAwake()
        {
            _filter = World.Filter.With<MoveDirection>().With<MoveSpeed>().With<Position>().Build();
            _moveDirectionStash = World.GetStash<MoveDirection>();
            _moveSpeedStash = World.GetStash<MoveSpeed>();
            _positionStash = World.GetStash<Position>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                MoveDirection direction = _moveDirectionStash.Get(entity);
                MoveSpeed moveSpeed = _moveSpeedStash.Get(entity);
                ref Position position =  ref _positionStash.Get(entity);
                
                position.Value += direction.Value * (moveSpeed.Value * deltaTime);
            }
        }

        public void Dispose()
        {
        }
    }
}