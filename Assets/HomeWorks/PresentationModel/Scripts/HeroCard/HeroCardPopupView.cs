using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popup
{
    public sealed class HeroCardPopupView : MonoBehaviour, IDisposable
    {
        [Header("Character")]
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _description;
        [Header("Experience")]
        [SerializeField] private TMP_Text _exp;
        [SerializeField] private Slider _expSlider;
        [Header("Stats")]
        [SerializeField] private TMP_Text _moveSpeed;
        [SerializeField] private TMP_Text _stamina;
        [SerializeField] private TMP_Text _dexterity;
        [SerializeField] private TMP_Text _intelligence;
        [SerializeField] private TMP_Text _damage;
        [SerializeField] private TMP_Text _regeneration;
        [Header("Buttons")]
        [SerializeField] private CloseButton _closeButton;
        [SerializeField] private LevelUpButton _levelUpButton;
        
        private IHeroCardViewModel _heroCardViewModel;
        private DisposableBag _disposables;

        public void Show(IViewModel viewModel)
        {
            if (viewModel is not IHeroCardViewModel heroCardViewModel)
                throw new Exception("ViewModel must be IHeroCardViewModel");
            
            _heroCardViewModel = heroCardViewModel;

            Subscribes();
            gameObject.SetActive(true);
        }

        
        private void Subscribes()
        {
            _heroCardViewModel.Title.Subscribe(title => _title.text = title)
                .AddTo(ref _disposables);
            _heroCardViewModel.Avatar.Subscribe(avatar => _avatar.sprite = avatar)
                .AddTo(ref _disposables);
            _heroCardViewModel.Description.Subscribe(description => _description.text = description)
                .AddTo(ref _disposables);
            _heroCardViewModel.Experience.Subscribe(experience => _exp.text = experience.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Experience.Subscribe(experience => _expSlider.value = experience)
                .AddTo(ref _disposables);
            _heroCardViewModel.CanLevelUp.Subscribe(canLevelUp => _levelUpButton.SetAvailable(canLevelUp))
                .AddTo(ref _disposables);
            _heroCardViewModel.Level.Subscribe(level =>_level.text = level.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.MoveSpeed.Subscribe(moveSpeed => _moveSpeed.text = moveSpeed.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Stamina.Subscribe(stamina => _stamina.text = stamina.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Dexterity.Subscribe(dexterity => _dexterity.text = dexterity.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Intelligence.Subscribe(intelligence => _intelligence.text = intelligence.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Damage.Subscribe(damage => _damage.text = damage.ToString())
                .AddTo(ref _disposables);
            _heroCardViewModel.Regeneration.Subscribe(regeneration => _regeneration.text = regeneration.ToString())
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
            if (_heroCardViewModel.CanLevelUp.CurrentValue)
                _heroCardViewModel.LevelUp();
        }

        public void Dispose()
        {
            _closeButton.RemoveListener(OnCloseButtonClicked);
            _levelUpButton.RemoveListener(OnLevelUpButtonClicked);
            _disposables.Dispose();
        }
    }
}
