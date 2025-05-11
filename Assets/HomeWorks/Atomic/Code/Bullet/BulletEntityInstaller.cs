using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class BulletEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private BulletInstaller _bulletInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        public override void Install(IEntity entity)
        {
            _bulletInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
        }
    }

    public class BulletBehaviour : IEntityInit
    {
        private IEvent _shootEvent;
        private IReactiveVariable<Vector3> _direction;
        private IReactiveVariable<float> _moveSpeed;

        public void Init(IEntity entity)
        {
            //_direction = entity.GetMoveDirection();
            //_moveSpeed = entity.GetMoveSpeed();
            
            _shootEvent = entity.GetDealDamageEvent();
            _shootEvent.Subscribe(OnShootEvent);
        }

        public void OnShootEvent()
        {
            Debug.Log("Killed someone");
        }
    }
}