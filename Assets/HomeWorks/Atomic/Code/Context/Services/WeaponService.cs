using System;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class WeaponService
    {
        public SceneEntity Weapon {get; private set;}
        public WeaponConfig WeaponConfig;
        
        public void SetWeaponEntity(SceneEntity weaponEntity)
        {
            Weapon = weaponEntity;
        }
    }
}