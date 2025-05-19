using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ShootEmUp.HomeWorks.ECS
{
    public class TransformViewSystem : IEcsPostRunSystem
    {
        private EcsFilterInject<Inc<TransformViewComponent, PositionComponent>> _filter;
        
        public void PostRun(IEcsSystems systems)
        {
            foreach (var e in _filter.Value)
            {
                ref var TransformView = ref _filter.Pools.Inc1.Get(e);
                ref var position = ref _filter.Pools.Inc2.Get(e);
                
                TransformView.Transform.position = position.Position;
            }
        }
    }
}