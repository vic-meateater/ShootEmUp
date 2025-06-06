using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using ShootEmUp.Homeworks.ECSGame;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class DeathCleanupSystem : ICleanupSystem
    {
        public World World { get; set; }
        private Filter _filter;
        
        private Stash<IsDeath> _isDeathStash;
        private Stash<ReadyToClean> _readyToCleanStash;
        private Stash<MoveDirection> _moveDirectionStash;
        private Stash<TransformView> _transformViewStash;
        
        public void OnAwake()
        {
            _filter = World.Filter.With<IsDeath>().With<ReadyToClean>().With<MoveDirection>().Build();
            _isDeathStash = World.GetStash<IsDeath>();
            _readyToCleanStash = World.GetStash<ReadyToClean>();
            _moveDirectionStash = World.GetStash<MoveDirection>();
            _transformViewStash = World.GetStash<TransformView>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveDirection = ref _moveDirectionStash.Get(entity);
                moveDirection.Value = Vector3.zero;
                
                _readyToCleanStash.Remove(entity);
                _isDeathStash.Remove(entity);
                
                var go = _transformViewStash.Get(entity).Value.gameObject;
                GameObject.Destroy(go);
            }
        }

        public void Dispose()
        {

        }
    }
}