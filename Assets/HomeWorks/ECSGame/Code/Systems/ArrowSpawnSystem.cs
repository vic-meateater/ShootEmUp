using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ArrowSpawnSystem : ISystem
    {
        public World World { get; set; }
        
        private Request<ArrowSpawnRequest> _spawnArrowRequest;

        public void OnAwake()
        {
            _spawnArrowRequest = World.GetRequest<ArrowSpawnRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var request in _spawnArrowRequest.Consume())
            {
                Debug.Log($"{request.Requester.Id} Spawn Arrow Requested");
            }
        }

        public void Dispose()
        {
        }
    }
}