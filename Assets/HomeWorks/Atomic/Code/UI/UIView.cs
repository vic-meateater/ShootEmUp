using System;
using Atomic.Elements;
using Atomic.Entities;
using TMPro;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIView : MonoBehaviour, IDisposable
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _ammoText;
        [SerializeField] private TMP_Text _killedText;
        [SerializeField] private GameObject _endGameScreen;
        
        private IUIViewModel _viewModel;
        private string _currentBullets = "";
        private string _maxBullets = "";

        public void Init(IUIViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.CurrentHealth.Subscribe(OnHealthChanged);
            _viewModel.IsDead.Subscribe(OnIsDeadAction);
            _viewModel.CurrentBullets.Subscribe(OnCurrentBulletsChanged);
            _viewModel.MaxBullets.Subscribe(OnMaxBulletsChanged);
            _viewModel.Kills.Subscribe(OnKillsChanged);
        }

        private void OnKillsChanged(int killedCount)
        {
            _killedText.text = $"KILLS: {killedCount.ToString()}";
        }

        private void OnMaxBulletsChanged(int maxBullets)
        {
            _maxBullets = maxBullets.ToString();
            _ammoText.text = $"BULLETS: {_currentBullets}/{_maxBullets}";
        }

        private void OnCurrentBulletsChanged(int currentBullets)
        {
            _currentBullets = currentBullets.ToString();
            _ammoText.text = $"BULLETS: {_currentBullets}/{_maxBullets}";
        }

        private void OnIsDeadAction(bool isDead)
        {
            if (isDead)
                _endGameScreen.gameObject.SetActive(true);
        }

        private void OnHealthChanged(float currentHealth)
        {
            _healthText.text = $"HIT POINTS: {currentHealth}";
        }

        public void Dispose()
        {
            _viewModel.CurrentHealth.Unsubscribe(OnHealthChanged);
            _viewModel.IsDead.Unsubscribe(OnIsDeadAction);
            _viewModel.CurrentBullets.Unsubscribe(OnCurrentBulletsChanged);
            _viewModel.MaxBullets.Unsubscribe(OnMaxBulletsChanged);
            _viewModel.Kills.Unsubscribe(OnKillsChanged);
        }
    }
}
