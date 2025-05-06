using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        public override void Install(IEntity entity)
        {
            _healthInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
        }
    }
}
