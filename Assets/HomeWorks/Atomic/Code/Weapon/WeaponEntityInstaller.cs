using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class WeaponEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private WeaponInstaller _weaponInstaller;
        public override void Install(IEntity entity)
        {
            _weaponInstaller.Install(entity);
        }
    }
    
    [Serializable]
    public class WeaponInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _shootPoint;
        public void Install(IEntity entity)
        {
            entity.AddShootPoint(_shootPoint);
        }
    }
}