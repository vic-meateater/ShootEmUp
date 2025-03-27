using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameCycle
    {
        private readonly List<IGameListener> _gameListeners = new();

        public GameCycle()
        {
            EventManager.Instance.PlayButtonClicked += OnPlayButtonClicked;
            EventManager.Instance.PauseButtonClicked += OnPauseButtonClicked;
            EventManager.Instance.ResumeButtonClicked += OnResumeButtonClicked;
            EventManager.Instance.EndGameButtonClicked += OnEndGameButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            foreach (IGameListener listener in _gameListeners)
            {
                if (listener is IGameStartListener startListener)
                    startListener.OnStartGame();
            }
        }
        private void OnPauseButtonClicked()
        {
            foreach (IGameListener listener in _gameListeners)
            {
                if (listener is IGamePauseListener pauseListener)
                    pauseListener.OnPauseGame();
            }
        }
        private void OnResumeButtonClicked()
        {
            foreach (IGameListener listener in _gameListeners)
            {
                if (listener is IGameResumeListener resumeListener)
                    resumeListener.OnResumeGame();
            }
        }

        private void OnEndGameButtonClicked()
        {
            foreach (IGameListener listener in _gameListeners)
            {
                if (listener is IGameStopListener stopListener)
                    stopListener.OnStopGame();
            }
        }
        public void AddListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);
        }
    }
}
