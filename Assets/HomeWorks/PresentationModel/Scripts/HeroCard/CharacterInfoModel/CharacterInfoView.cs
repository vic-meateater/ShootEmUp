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

        private ICharacterInfoViewModel _characterInfoViewModel;
        private DisposableBag _disposables;
        
        public void Init(ICharacterInfoViewModel characterInfoViewModel)
        {
            _characterInfoViewModel = characterInfoViewModel;

            Subscribes();
        }

        private void Subscribes()
        {
            
            _characterInfoViewModel.Title.Subscribe(title => _title.text = title)
                .AddTo(ref _disposables);
            _characterInfoViewModel.Avatar.Subscribe(avatar => _avatar.sprite = avatar)
                .AddTo(ref _disposables);
            _characterInfoViewModel.Description.Subscribe(description => _description.text = description)
                .AddTo(ref _disposables);
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}