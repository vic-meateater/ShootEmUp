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
        private Stash<AttackRange> _attackRangeStash;
        private Stash<MoveDirection> _moveDirectionStash;
        private Stash<Rotation> _rotationStash;
        private Stash<IsDeath> _isDeathStash;
        
        private Collider[] _results = new Collider[10];
        private Vector3 _targetPosition;

        public void OnAwake()
        {
            _filter = World.Filter
                .With<TeamComponent>()
                .With<Health>()
                .With<Position>()
                .With<AttackRange>()
                .With<TestComponent>()
                .Build();
            
            _teamStash = World.GetStash<TeamComponent>();
            _healthStash = World.GetStash<Health>();
            _positionStash = World.GetStash<Position>();
            _attackRangeStash = World.GetStash<AttackRange>();
            _moveDirectionStash = World.GetStash<MoveDirection>();
            _positionStash = World.GetStash<Position>();
            _rotationStash = World.GetStash<Rotation>();
            _isDeathStash = World.GetStash<IsDeath>();

            _fireRequest = World.GetRequest<FireRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                Position position = _positionStash.Get(entity);
                TeamComponent attackerTeam = _teamStash.Get(entity);
                AttackRange attackRange = _attackRangeStash.Get(entity);
                
                _targetPosition = Vector3.zero;
                
                int size = Physics.OverlapSphereNonAlloc(position.Value, attackRange.Value, _results, -1);
                for (int i = 0; i < size; i++)
                {
                    if (_results[i].TryGetComponent<EntityProvider>(out var provider) &&
                        _teamStash.Has(provider.Entity) && 
                        !_isDeathStash.Has(provider.Entity))
                    {
                        Entity target = provider.Entity;
                        TeamComponent targetTeam = _teamStash.Get(target);
                        if (attackerTeam.Team != targetTeam.Team)
                        {
                            Vector3 targetPosition = _positionStash.Get(target).Value;
                            _fireRequest.Publish(new FireRequest {Requester = entity, Target = target});
                            SetRotation(entity, position.Value, targetPosition);
                        }
                    }
                }
            }
        }

        private void SetRotation(Entity entity, Vector3 position, Vector3 targetPosition)
        {
            Vector3 directionToTarget = (targetPosition - position).normalized;
            directionToTarget.y = 0; // Игнорируем вертикаль
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            
            _rotationStash.Set(entity, new Rotation{Value = targetRotation});
        }

        public void Dispose()
        {

        }
    }
}