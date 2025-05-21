using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.Homeworks.ECSGame
{
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]

    public sealed class HealthSystem : ISystem
    {
        public World World { get; set; }
        
        private Filter _filter;
        private Stash<Health> _healthStash;

        public void OnAwake()
        {
            _filter = World.Filter.With<Health>().Build();
            _healthStash = World.GetStash<Health>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref Health health = ref _healthStash.Get(entity);
                if (health.Value <= 0)
                    Debug.Log("Someone died");
            }
        }

        public void Dispose()
        {

        }
    }
}