using Scellecs.Morpeh;
using ShootEmUp.Homeworks.ECSGame;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PositionInitializer : IInitializer
    {
        public World World { get; set; }
        
        private Filter _filter;
        private Stash<TransformView> _transformViewStash;
        private Stash<Position> _positionStash;
        private Stash<Rotation> _rotationStash;

        public void OnAwake()
        {
            _filter = World.Filter.With<TransformView>().With<Position>().With<Rotation>().Build();
            _transformViewStash = World.GetStash<TransformView>();
            _positionStash = World.GetStash<Position>();
            _rotationStash = World.GetStash<Rotation>();

            foreach (var entity in _filter)
            {
                ref Position position = ref _positionStash.Get(entity);
                ref Rotation rotation = ref _rotationStash.Get(entity);
                TransformView transformView = _transformViewStash.Get(entity);
                
                // position.Value.x = transformView.Value.position.x;
                // position.Value.y = transformView.Value.position.y;
                // position.Value.z = transformView.Value.position.z;

                position.Value = transformView.Value.position;
                
                rotation.Value = transformView.Value.rotation;
                
            }
        }

        public void Dispose()
        {
        }
    }
}