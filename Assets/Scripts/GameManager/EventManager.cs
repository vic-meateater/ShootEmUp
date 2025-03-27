using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EventManager
    {
        private static readonly Lazy<EventManager> _instance = new Lazy<EventManager>(() => new EventManager());
        public static EventManager Instance => _instance.Value;
        private EventManager() { }
        public event Action Fire;
        public event Action<GameObject> EnemyReachedDestination;
        public event Action<float> PlayerInputChanged;
        public event Action PlayButtonClicked;
        public event Action PauseButtonClicked;
        public event Action ResumeButtonClicked;
        public event Action EndGameButtonClicked;

        public void OnFire()
        {
            Fire?.Invoke();
        }
        public void OnEnemyReachedDestination(GameObject enemy)
        {
            EnemyReachedDestination?.Invoke(enemy);
        }

        public void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }

        public void OnPauseButtonClicked()
        {
            PauseButtonClicked?.Invoke();
        }

        public void OnEndGameButtonClicked()
        {
            EndGameButtonClicked?.Invoke();
        }

        public void OnResumeButtonClicked()
        {
            ResumeButtonClicked?.Invoke();
        }

        public void OnPlayerInputChanged(float horizontalDirection)
        {
            PlayerInputChanged?.Invoke(horizontalDirection);
        }
    }
}