using System;
using R3;
using UnityEngine;

namespace Popup
{
    public sealed class HeroCardPopupView : MonoBehaviour, IDisposable
    {
        [Header("Views")]
        [SerializeField] private CharacterInfoView _characterInfoView;
        [SerializeField] private LevelView _levelView;
        [SerializeField] private ExperienceView _experienceView;
        [SerializeField] private StatsView _statsView;
        
        [Header("Buttons")]
        [SerializeField] private CloseButton _closeButton;
        [SerializeField] private LevelUpButton _levelUpButton;
        
        
        private IHeroCardViewModel _heroCardViewModel;
        private ICharacterInfoViewModel _characterInfoViewModel;
        private ILevelViewModel _levelViewModel;
        private IExperienceViewModel _experienceViewModel;
        private IStatsViewModel _statsViewModel;
        
        private DisposableBag _disposables;

        public void Show(IViewModel viewModel)
        {
            if (viewModel is not IHeroCardViewModel heroCardViewModel)
                throw new Exception("ViewModel must be IHeroCardViewModel");
            
            _heroCardViewModel = heroCardViewModel;
            _characterInfoViewModel = _heroCardViewModel.CharacterInfoViewModel;
            _levelViewModel = _heroCardViewModel.LevelViewModel;
            _experienceViewModel = _heroCardViewModel.ExperienceViewModel;
            _statsViewModel = _heroCardViewModel.StatsViewModel;

            _characterInfoView.Init(_characterInfoViewModel);
            _levelView.Init(_levelViewModel);
            _experienceView.Init(_experienceViewModel);
            _statsView.Init(_statsViewModel);
            
            Subscribes();
            gameObject.SetActive(true);
        }
        
        private void Subscribes()
        {
            _levelViewModel.CanLevelUp.Subscribe(canLevelUp => _levelUpButton.SetAvailable(canLevelUp))
                .AddTo(ref _disposables);
            
            _levelUpButton.AddListener(OnLevelUpButtonClicked);
            _closeButton.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            gameObject.SetActive(false);
        }

        private void OnLevelUpButtonClicked()
        {
            if (_levelViewModel.CanLevelUp.CurrentValue)
            {
                _heroCardViewModel.LevelUp();
                _experienceView.ResetSlider();
            }
        }

        public void Dispose()
        {
            _closeButton.RemoveListener(OnCloseButtonClicked);
            _levelUpButton.RemoveListener(OnLevelUpButtonClicked);
            _disposables.Dispose();
        }
    }
}
