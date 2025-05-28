using Scellecs.Morpeh;
using ShootEmUp.HomeWorks.ECSGame;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class FireRequestSystem : ISystem
    {
        public World World { get; set; }
        
        private ArrowConfig _arrowConfig;
        private FireRequest _fireRequest;
        
        public void Initialize(ArrowConfig arrowConfig)
        {
            _arrowConfig = arrowConfig;
        }

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