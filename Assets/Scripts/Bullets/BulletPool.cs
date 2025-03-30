using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletPool: MonoMemoryPool<Vector3, Bullet>
    {
        protected override void Reinitialize(Vector3 position, Bullet bullet)
        {
            bullet.SetPosition(position);
            bullet.gameObject.SetActive(true);
            bullet.SetPool(this);
        }

        protected override void OnDespawned(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }
    }
}