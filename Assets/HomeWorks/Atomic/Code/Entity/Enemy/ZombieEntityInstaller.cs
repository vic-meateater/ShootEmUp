using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic.HomeWorks.Atomic.Code.Entity.Enemy
{
    public class ZombieEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private WeaponSlotInstaller _weaponSlotInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        [SerializeField] private AnimatorInstaller _animatorInstaller;
        public override void Install(IEntity entity)
        {
            _healthInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
            _weaponSlotInstaller.Install(entity);
            _animatorInstaller.Install(entity);
        }
    }

    public class ZombieBehaviour : IEntityInit
    {
        private IReactiveVariable<Vector3> _moveDirection;

        public void Init(IEntity entity)
        {
        }

    }
}