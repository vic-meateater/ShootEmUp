using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class ZombieEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private WeaponSlotInstaller _weaponSlotInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        [SerializeField] private AnimatorInstaller _animatorInstaller;
        [SerializeField] private EnemyInstaller _enemyInstaller;

        public override void Install(IEntity entity)
        {
            _healthInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
            _weaponSlotInstaller.Install(entity);
            _animatorInstaller.Install(entity);
            _enemyInstaller.Install(entity);
        }
    }

    public class EnemyBehaviour : IEntityInit
    {
        private IEvent _isDeadEvent;
        private float _respawnTimer;
        private IReactiveVariable<bool> _isDead;
        private IReactiveVariable<Vector3> _moveDirection;
        private IEvent<IEntity> _spawnedEvent;
        private ReactiveVector3 _movePosition;
        private IReactiveVariable<float> _moveSpeed;
        private Rigidbody _rb;
        private IReactiveVariable<Vector3> _lookPoint;

        public void Init(IEntity entity)
        {
            
            _moveDirection = entity.GetMoveDirection();
            _movePosition = entity.GetMovePosition();
            _moveSpeed = entity.GetMoveSpeed();
            _lookPoint = entity.GetLookPoint();
            _rb = entity.GetRigidbody();

            _isDeadEvent = entity.GetCharacterDieEvent();
            _isDeadEvent.Subscribe(OnIsDeadEventAction);

            
            _isDead = entity.GetIsDead();
            _isDead.Subscribe(OnIsDeadAction);
            
            _spawnedEvent = entity.GetSpawnedEvent();
            _spawnedEvent.Subscribe(OnSpawnedAction);
        }


        private void OnSpawnedAction(IEntity playerEntity)
        {
            PlayerPositionChanged(playerEntity.GetMovePosition().Value);
            playerEntity.GetMovePosition().OnValueChanged += PlayerPositionChanged;
        }

        private void PlayerPositionChanged(Vector3 playerPosition)
        {
            if (!_isDead.Value)
            {
                var direction = (playerPosition - _movePosition.Value).normalized;
                _moveDirection.Value = direction;
                _lookPoint.Value = playerPosition;
            }
        }

        private void OnIsDeadAction(bool isDead)
        {
            _moveSpeed.Value = 0;
        }

        private void OnIsDeadEventAction()
        {
            _isDead.Value = false;
        }
    }

    [Serializable]
    public class EnemyInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddSpawnedEvent(new Event<IEntity>());

            entity.AddBehaviour(new EnemyBehaviour());
        }
    }
}