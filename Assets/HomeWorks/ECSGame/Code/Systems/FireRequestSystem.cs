using Scellecs.Morpeh;
using ShootEmUp.HomeWorks.ECSGame;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class FireRequestSystem : ISystem
    {
        public World World { get; set; }

        private ArrowConfig _arrowConfig;

        private Filter _filter;
        private Request<FireRequest> _fireRequest;
        private Event<FireEvent> _fireEvent;
        private Stash<MoveDirection> _moveDirectionStash;


        public void Initialize(ArrowConfig arrowConfig)
        {
            _arrowConfig = arrowConfig;
        }

        public void OnAwake()
        {
            _fireRequest = World.GetRequest<FireRequest>();
            _moveDirectionStash = World.GetStash<MoveDirection>();
            _filter = World.Filter.With<MoveDirection>().Build();
            _fireEvent = World.GetEvent<FireEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var request in _fireRequest.Consume())
            {
                ref var moveDirection = ref _moveDirectionStash.Get(request.Requester);
                moveDirection.Value = Vector3.zero;
                _fireEvent.NextFrame(new FireEvent { Entity = request.Requester });
            }
        }

        public void Dispose()
        {
        }
    }
}