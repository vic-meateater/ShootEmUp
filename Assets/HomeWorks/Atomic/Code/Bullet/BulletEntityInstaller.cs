using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

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

    [Serializable]
    public class BulletInstaller : IEntityInstaller
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private SceneEntity _weaponEntity;

        public void Install(IEntity entity)
        {
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddBulletSpawnPoint(_weaponEntity.Entity.GetShootPoint());
            entity.AddBehaviour(new BulletBehaviour());
            entity.AddDealDamageEvent(new Event());
        }
    }

    public class BulletBehaviour : IEntityInit, IEntityUpdate
    {
        private GameObject _bulletPrefab;
        private IEvent _shootEvent;
        private Transform _bulletSpawnPoint;
        private GameObject _bulletInstance;
        private IReactiveVariable<Vector3> _direction;
        private IReactiveVariable<float> _moveSpeed;

        public void Init(IEntity entity)
        {
            _bulletPrefab = entity.GetBulletPrefab();
            _bulletSpawnPoint = entity.GetBulletSpawnPoint();
            _direction = entity.GetMoveDirection();
            _moveSpeed = entity.GetMoveSpeed();
            
            _shootEvent = entity.GetDealDamageEvent();
            _shootEvent.Subscribe(OnShootEvent);
        }

        public void OnShootEvent()
        {
            Debug.Log("Bullet fired");
            _bulletInstance = GameObject.Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
            _direction.Value = _bulletInstance.transform.position - _bulletSpawnPoint.position;
            _direction.Value.Normalize();
            _direction.Value *= _moveSpeed.Value;
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
           // throw new NotImplementedException();
        }
    }
}