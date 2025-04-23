using System;
using R3;
using TMPro;
using UnityEngine;

namespace Popup
{
    public class LevelView: MonoBehaviour, IDisposable
    {
        [SerializeField] private TMP_Text _level;
        
        private ILevelViewModel _levelViewModel;
        private DisposableBag _disposables;
        
        public void Init(ILevelViewModel levelViewModel)
        {
            _levelViewModel = levelViewModel;

            Subscribes();
        }

        private void Subscribes()
        {
            _levelViewModel.Level.Subscribe(level =>_level.text = level.ToString())
                .AddTo(ref _disposables);
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}