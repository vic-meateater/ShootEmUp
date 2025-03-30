using System.Collections;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class UIViewController
    {
        private const int COUNTDOWN_TIMEOUT = 3;
        [Inject] private readonly UIView _uiView;

        [Inject]
        private void Init()
        {
            _uiView.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            _uiView.PauseButton.onClick.AddListener(OnPauseButtonClicked);
            _uiView.ResumeButton.onClick.AddListener(OnResumeButtonClicked);
            _uiView.EndGameButton.onClick.AddListener(OnEndGameButtonClicked);

            EventManager.Instance.EndGameButtonClicked += OnEndGame;
            _uiView.PlayButton.gameObject.SetActive(true);
            _uiView.PauseButton.gameObject.SetActive(false);
            _uiView.ResumeButton.gameObject.SetActive(false);
            _uiView.EndGameButton.gameObject.SetActive(false);
        }

        private void OnEndGame()
        {
            _uiView.Countdown.text = "Game over";
        }

        private void OnPlayButtonClicked()
        {
            _uiView.StartCoroutine(StartCountdown(COUNTDOWN_TIMEOUT));
            _uiView.PlayButton.gameObject.SetActive(false);
        }

        private IEnumerator StartCountdown(int count)
        {
            for (int i = count; i > 0; i--)
            {
                _uiView.Countdown.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            _uiView.PauseButton.gameObject.SetActive(true);
            _uiView.ResumeButton.gameObject.SetActive(false);
            _uiView.EndGameButton.gameObject.SetActive(true);
            _uiView.Countdown.text = "";
            EventManager.Instance.OnPlayButtonClicked();
        }

        private void OnPauseButtonClicked()
        {
            EventManager.Instance.OnPauseButtonClicked();
            _uiView.PauseButton.gameObject.SetActive(false);
            _uiView.ResumeButton.gameObject.SetActive(true);
        }

        private void OnResumeButtonClicked()
        {
            EventManager.Instance.OnResumeButtonClicked();
            _uiView.ResumeButton.gameObject.SetActive(false);
            _uiView.PauseButton.gameObject.SetActive(true);
        }

        private void OnEndGameButtonClicked()
        {
            EventManager.Instance.OnEndGameButtonClicked();
            _uiView.PauseButton.gameObject.SetActive(false);
            _uiView.ResumeButton.gameObject.SetActive(false);
            _uiView.EndGameButton.gameObject.SetActive(false);
        }
    }
}