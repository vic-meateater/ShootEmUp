using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class BulletEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private BulletInstaller _bulletInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        public override void Install(IEntity entity)
        {
            _bulletInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
            _healthInstaller.Install(entity);
        }
    }
}