using System;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class PlayerService
    {
        public SceneEntity PlayerEntity;
        public SceneEntity Weapon;
        public SceneEntity Bullet;

        public void SetPlayerEntity(SceneEntity playerEntity)
        {
            PlayerEntity = playerEntity;
        }

        public void SetWeaponEntity(SceneEntity weaponEntity)
        {
            Weapon = weaponEntity;
        }
        
        public void SetBulletEntity(SceneEntity bulletEntity)
        {
            Bullet = bulletEntity;
        }
    }
}