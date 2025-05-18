using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class WeaponSlotInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _weaponSlot;

        public void Install(IEntity entity)
        {
            entity.AddWeaponSlot(_weaponSlot);
        }
    }
}