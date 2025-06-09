using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class AIInputSystem : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Stash<Position> _positionStash;
        private Stash<Rotation> _rotationStash;
        private Stash<MoveSpeed> _moveSpeedStash;
        private Stash<WantsToMove> _wantsToMoveStash;

        public void OnAwake()
        {
            _filter = World.Filter
                .With<MoveSpeed>()
                .With<Rotation>()
                .With<Position>()
                .Build();

            _positionStash = World.GetStash<Position>();
            _rotationStash = World.GetStash<Rotation>();
            _moveSpeedStash = World.GetStash<MoveSpeed>();
            _wantsToMoveStash = World.GetStash<WantsToMove>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                bool conditionToMove = true; 

                if (conditionToMove)
                {
                    if (!_wantsToMoveStash.Has(entity))
                        _wantsToMoveStash.Add(entity);
                }
                else
                {
                    if (_wantsToMoveStash.Has(entity))
                        _wantsToMoveStash.Remove(entity);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}