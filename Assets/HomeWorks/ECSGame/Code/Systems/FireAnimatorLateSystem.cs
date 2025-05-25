using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ShootEmUp.Homeworks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class FireAnimatorLateSystem : ILateSystem
    {
        public World World { get; set; }
        
        private Request<FireRequest> _fireRequest;
        private Event<FireEvent> _fireEvent;

        private Filter _filter;
        private Stash<AnimatorView> _animatorViewStash;

        public void OnAwake()
        {
            _filter = World.Filter.With<AnimatorView>().Build();
            _animatorViewStash = World.GetStash<AnimatorView>();
            _fireRequest = World.GetRequest<FireRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void Dispose()
        {
        }
    }
}