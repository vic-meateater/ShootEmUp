using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class EnemyDetectionSystem : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Stash<TeamComponent> _teamStash;
        private Stash<Health> _healthStash;

        public void OnAwake()
        {

        }

        public void OnUpdate(float deltaTime)
        {

        }

        public void Dispose()
        {

        }
    }
}