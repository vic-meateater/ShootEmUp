using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class UIViewController
    {
        private const int COUNTDOWN_TIMEOUT = 3;
        private readonly UIView _uiView;

        public UIViewController(UIView uiView)
        {
            _uiView = uiView;

            _uiView.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            _uiView.PauseButton.onClick.AddListener(OnPauseButtonClicked);
            _uiView.ResumeButton.onClick.AddListener(OnResumeButtonClicked);
            _uiView.EndGameButton.onClick.AddListener(OnEndGameButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            _uiView.StartCoroutine(StartCountdown(COUNTDOWN_TIMEOUT));
        }
        
        private IEnumerator StartCountdown(int count)
        {
            for (int i = count; i > 0; i--)
            {
                _uiView.Countdown.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            _uiView.Countdown.text = "";
            _uiView.PlayButton.gameObject.SetActive(false);
            EventManager.Instance.OnPlayButtonClicked();
        }

        private void OnPauseButtonClicked()
        {
            EventManager.Instance.OnPauseButtonClicked();
        }

        private void OnResumeButtonClicked()
        {
            EventManager.Instance.OnResumeButtonClicked();
        }

        private void OnEndGameButtonClicked()
        {
            EventManager.Instance.OnEndGameButtonClicked();
        }
    }
}