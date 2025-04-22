using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popup
{
    public class CharacterInfoView : MonoBehaviour, IDisposable
    {
        [Header("Character")] 
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _description;

        private IHeroCardViewModel _heroCardViewModel;
        private DisposableBag _disposables;
        
        public void Init(IHeroCardViewModel heroCardViewModel)
        {
            _heroCardViewModel = heroCardViewModel;

            Subscribes();
        }

        private void Subscribes()
        {
            _heroCardViewModel.Title.Subscribe(title => _title.text = title)
                .AddTo(ref _disposables);
            _heroCardViewModel.Avatar.Subscribe(avatar => _avatar.sprite = avatar)
                .AddTo(ref _disposables);
            _heroCardViewModel.Description.Subscribe(description => _description.text = description)
                .AddTo(ref _disposables);
            _heroCardViewModel.Level.Subscribe(level =>_level.text = level.ToString())
                .AddTo(ref _disposables);
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}