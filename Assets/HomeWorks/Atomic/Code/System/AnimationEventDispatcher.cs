using System;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class AnimationEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            OnEventReceived?.Invoke(key);
        }
    }
}