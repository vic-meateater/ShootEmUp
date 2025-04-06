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
        [SerializeField] private Button _closeButton;
        [SerializeField] private LevelUpButton _levelUpButton;
        
        private IHeroCardViewModel _heroCardViewModel;
        private readonly DisposableBag _disposables = new();

        public void Show(IViewModel viewModel)
        {
            if (viewModel is not IHeroCardViewModel heroCardViewModel)
                throw new Exception("ViewModel must be IHeroCardViewModel");
            
            _heroCardViewModel = heroCardViewModel;

            Subscribes();
            UpdateUI();
        }

        
        private void Subscribes()
        {
            //_heroCardViewModel.Experience.Subscribe(UpdateExperience).RegisterTo(destroyCancellationToken);
            _heroCardViewModel.Experience.Subscribe(value => _exp.text = value.ToString());
            _heroCardViewModel.Experience.Subscribe(value => _expSlider.value = value);
            _heroCardViewModel.CanLevelUp.Subscribe(value => 
                _levelUpButton.SetAvailable(value));
            _heroCardViewModel.Level.Subscribe(value =>_level.text = value.ToString());
            
            _levelUpButton.AddListener(OnLevelUpButtonClicked);
        }


        private void UpdateUI()
        {
            _title.text = _heroCardViewModel.Title;
            _avatar.sprite = _heroCardViewModel.Avatar;
            //_level.text = _heroCardViewModel.Level.ToString();
            _description.text = _heroCardViewModel.Description;
            //_exp.text = _heroCardViewModel.Experience.ToString();
            //_expSlider.value = _heroCardViewModel.Experience.CurrentValue;
            _moveSpeed.text = _heroCardViewModel.MoveSpeed.ToString();
            _stamina.text = _heroCardViewModel.Stamina.ToString();
            _dexterity.text = _heroCardViewModel.Dexterity.ToString();
            _intelligence.text = _heroCardViewModel.Intelligence.ToString();
            _damage.text = _heroCardViewModel.Damage.ToString();
            _regeneration.text = _heroCardViewModel.Regeneration.ToString();
        }
        private void OnLevelUpButtonClicked()
        {
            if (_heroCardViewModel.CanLevelUp.CurrentValue)
                _heroCardViewModel.LevelUp();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
