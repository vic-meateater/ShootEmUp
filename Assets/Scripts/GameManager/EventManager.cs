using System;

namespace ShootEmUp
{
    public class EventManager
    {
        public event Action OnFire;

        public void Fire()
        {
            OnFire?.Invoke();
        }
    }
}