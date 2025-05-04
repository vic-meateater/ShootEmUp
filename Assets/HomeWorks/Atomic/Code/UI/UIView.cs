using System;
using Atomic.Elements;
using Atomic.Entities;
using TMPro;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SceneEntity _sceneEntity;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _ammoText;
        [SerializeField] private TMP_Text _killedText;
        [SerializeField] private GameObject _endGameScreen;
        
        private IReactiveVariable<float> _currentHealth;
        private IReactiveVariable<bool> _isDead;

        private void Start()
        {
            _currentHealth = _sceneEntity.Entity.GetCurrentHealth();
            _currentHealth.Subscribe(OnHealthChanged);

            _isDead = _sceneEntity.Entity.GetIsDead();
            _isDead.Subscribe(OnIsDead);
            
            _healthText.text = $"HIT POINTS: {_currentHealth.Value}";
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
            _currentHealth.Unsubscribe(OnHealthChanged);
            _isDead.Unsubscribe(OnIsDead);
        }
    }
}
