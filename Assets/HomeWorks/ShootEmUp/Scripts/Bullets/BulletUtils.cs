using UnityEngine;

namespace ShootEmUp
{
    class BulletUtils
    {
        public void DealDamage(Bullet bullet, Collision2D collision)
        {
            var target = collision.gameObject;
            if (!target.TryGetComponent(out ITeammate team))
                return;

            if (bullet.IsPlayer == team.IsPlayer)
                return;

            if (target.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(bullet.Damage);
            
        }
    }
}