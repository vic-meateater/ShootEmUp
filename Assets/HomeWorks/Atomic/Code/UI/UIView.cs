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
        
        private IReactiveVariable<bool> _isDead = new ReactiveVariable<bool>();
        private IUIViewModel _viewModel;

        public void Init(IUIViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.CurrentHealth.Subscribe(OnHealthChanged);
        }

        private void OnIsDead(bool isDead)
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
            _isDead.Unsubscribe(OnIsDead);
        }
    }
}
