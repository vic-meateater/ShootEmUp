using Scellecs.Morpeh;
using ShootEmUp.Homeworks.ECSGame;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class TransformViewSynchronizerSystem : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Filter _filterRotation;

        private Stash<TransformView> _transformViewStash;
        private Stash<Position> _positionStash;
        private Stash<Rotation> _rotationStash;

        public void OnAwake()
        {
            _filter = World.Filter.With<TransformView>().With<Position>().Build();
            _filterRotation = World.Filter.With<Rotation>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref TransformView transformView = ref _transformViewStash.Get(entity);
                Position position = _positionStash.Get(entity);
                
                transformView.Value.position = position.Value;
               
                if (_rotationStash.Has(entity))
                    transformView.Value.rotation = _rotationStash.Get(entity).Value;
            }
        }

        public void Dispose()
        {
        }
    }
}