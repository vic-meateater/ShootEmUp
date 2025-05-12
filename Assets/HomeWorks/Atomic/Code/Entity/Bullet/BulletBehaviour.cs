using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class BulletBehaviour : IEntityInit, IEntityUpdate
    {
        private IEvent _shootEvent;
        private IReactiveVariable<float> _moveSpeed;
        private IEvent<IEntity> _despawnEvent;
        private IEntity _bulletEntity;
        private float _destroyTimer;


        public void Init(IEntity entity)
        {
            _moveSpeed = entity.GetMoveSpeed();
            _bulletEntity =  entity;
            
            _shootEvent = entity.GetDealDamageEvent();
            _shootEvent.Subscribe(OnDealDamageAction);

            _despawnEvent = entity.GetDespawnEvent();
            
            _destroyTimer = 0f;
        }

        public void OnDealDamageAction()
        {
            _moveSpeed.Value = 0;
            _despawnEvent?.Invoke(_bulletEntity);
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var respawnInterval = 2f;
            _destroyTimer += deltaTime;
            if (_destroyTimer >= respawnInterval)
            {
                _despawnEvent?.Invoke(entity);
                _destroyTimer = 0f;
            }
        }
    }
}