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
        private IEvent<IEntity> _despawnEvent;
        private IEntity _bulletEntity;


        public void Init(IEntity entity)
        {
            //_direction = entity.GetMoveDirection();
            _moveSpeed = entity.GetMoveSpeed();
            _bulletEntity =  entity;
            
            _shootEvent = entity.GetDealDamageEvent();
            _shootEvent.Subscribe(OnDealDamageAction);

            _despawnEvent = entity.GetDespawnEvent();
        }

        public void OnDealDamageAction()
        {
            _moveSpeed.Value = 0;
            _despawnEvent?.Invoke(_bulletEntity);
        }
    }
}