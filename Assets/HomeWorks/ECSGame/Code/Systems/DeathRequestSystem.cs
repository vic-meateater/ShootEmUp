using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class DeathRequestSystem : ISystem
    {
        public World World { get; set; }
        private Filter _filter;
        private Stash<Health> _healthStash;
        private Stash<IsDeath> _isDeathStash;
        
        private Request<DeathRequest> _deathRequest;
        private Event<DeathEvent> _deathEvent;

        public void OnAwake()
        {
            _healthStash = World.GetStash<Health>();
            _isDeathStash = World.GetStash<IsDeath>();
            
            _deathRequest = World.GetRequest<DeathRequest>();
            _deathEvent = World.GetEvent<DeathEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var request in _deathRequest.Consume())
            {
                Health rHealth = _healthStash.Get(request.Requester);
                Health tHealth = _healthStash.Get(request.Target);

                if (rHealth.Value <= 0)
                {
                    _isDeathStash.Add(request.Requester);
                    _deathEvent.NextFrame(new DeathEvent {Entity = request.Requester});
                }
                
                if (tHealth.Value <= 0)
                {
                    _isDeathStash.Add(request.Target);
                    _deathEvent.NextFrame(new DeathEvent {Entity = request.Target});
                }
                    
            }
        }

        public void Dispose()
        {
        }
    }
}