using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ArrowSpawnRequestSystem : ISystem
    {
        public World World { get; set; }

        private Stash<Position> _stashPosition;
        private Stash<Rotation> _stashRotation;
        private Stash<MoveDirection> _stashMoveDirection;
        private Stash<RangeWeapon> _stashRangeWeapon;
        private Stash<Spawned> _stashSpawned;

        private Request<ArrowSpawnRequest> _spawnArrowRequest;


        public void OnAwake()
        {
            _stashPosition = World.GetStash<Position>();
            _stashRotation = World.GetStash<Rotation>();
            _stashRangeWeapon = World.GetStash<RangeWeapon>();
            _stashSpawned = World.GetStash<Spawned>();
            _stashMoveDirection = World.GetStash<MoveDirection>();

            _spawnArrowRequest = World.GetRequest<ArrowSpawnRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var request in _spawnArrowRequest.Consume())
            {
                var requester = request.Requester;
                Debug.Log($"{request.Requester.Id} Spawn Arrow Requested");
                Transform firePoint = _stashRangeWeapon.Get(requester).FirePoint;
                var prefab = _stashRangeWeapon.Get(requester).Prefab;

                var provider = GameObject.Instantiate(prefab, firePoint.position, firePoint.rotation);

                //_stashPosition.Get(provider.Entity).Value = provider.gameObject.transform.position;
                _stashPosition.Set(provider.Entity, new Position {Value = provider.gameObject.transform.position});
                //_stashRotation.Get(provider.Entity).Value = provider.gameObject.transform.rotation;
                _stashRotation.Set(provider.Entity, new Rotation {Value = provider.gameObject.transform.rotation});

                _stashMoveDirection.Set(provider.Entity, new MoveDirection {Value = firePoint.forward});
                _stashSpawned.Add(provider.Entity);
            }
        }

        public void Dispose()
        {
        }
    }
}