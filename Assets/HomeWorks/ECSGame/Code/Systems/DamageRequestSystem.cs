using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class DamageRequestSystem : ISystem
    {
        public World World { get; set; }

        private Stash<Health> _healthStash;
        private Stash<Damage> _damageStash;
        private Stash<IsDeath> _isDeathStash;
        
        private Request<DamageRequest> _damageRequest;
        private Request<DeathRequest> _deathRequest;
        private Event<DamageEvent> _damageEvent;

        public void OnAwake()
        {
            _damageStash = World.GetStash<Damage>();
            _healthStash = World.GetStash<Health>();
            _isDeathStash = World.GetStash<IsDeath>();
            
            _deathRequest = World.GetRequest<DeathRequest>();
            _damageRequest = World.GetRequest<DamageRequest>();
            _damageEvent = World.GetEvent<DamageEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var request in _damageRequest.Consume())
            {
                if(_isDeathStash.Has(request.Target)) return;
                
                Debug.Log($"Entity {request.Requester.Id} want damage Entity {request.Target.Id}");
                var requester = request.Requester;
                var target = request.Target;
                
                var damage = _damageStash.Get(requester);
                ref var tHealth = ref _healthStash.Get(target);
                
                tHealth.Value -= damage.Value;

                if (_healthStash.Has(requester))
                {
                    ref var rHealth = ref _healthStash.Get(requester);
                    rHealth.Value--;
                }
                
                _damageEvent.NextFrame(new DamageEvent{Entity = requester});
                _damageEvent.NextFrame(new DamageEvent{Entity = target});
                
                _deathRequest.Publish(new DeathRequest {Requester = requester, Target = target});
                
            }
        }

        public void Dispose()
        {

        }
    }
}