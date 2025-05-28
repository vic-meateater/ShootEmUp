using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class EnemyDetectionSystem : ISystem
    {
        public World World { get; set; }
        
        private Request<FireRequest> _fireRequest;

        private Filter _filter;
        private Stash<TeamComponent> _teamStash;
        private Stash<Health> _healthStash;
        private Stash<Position> _positionStash;
        
        private Collider[] _results = new Collider[10];

        public void OnAwake()
        {
            _filter = World.Filter.With<TeamComponent>().With<Health>().With<Position>().With<TestComponent>().Build();
            _teamStash = World.GetStash<TeamComponent>();
            _healthStash = World.GetStash<Health>();
            _positionStash = World.GetStash<Position>();
            
            _fireRequest = new Request<FireRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var position = _positionStash.Get(entity);
                var attackerTeam = _teamStash.Get(entity);
                var size = Physics.OverlapSphereNonAlloc(position.Value, 1f, _results);
                for (int i = 0; i < size; i++)
                {
                    var target = _results[i].GetComponent<EntityProvider>().Entity;
                    var targetTeam = _teamStash.Get(target);
                    if(attackerTeam.Team != targetTeam.Team)
                        _fireRequest.Publish(new FireRequest{Requester = entity, Target = target});
                }
            }
        }
        public void Dispose()
        {

        }
    }
}