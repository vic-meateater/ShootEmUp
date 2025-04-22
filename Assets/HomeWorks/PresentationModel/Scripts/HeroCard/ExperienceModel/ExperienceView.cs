using System;
using R3;
using TMPro;
using UnityEngine;

namespace Popup
{
    public class ExperienceView : MonoBehaviour, IDisposable
    {
        [Header("Experience")]
        [SerializeField] private TMP_Text _exp;
        [SerializeField] private ExpSlider _expSlider;
        
        private IHeroCardViewModel _heroCardViewModel;
        private DisposableBag _disposables;
        
        public void Init(IHeroCardViewModel heroCardViewModel)
        {
            _heroCardViewModel = heroCardViewModel;

            Subscribes();
        }

        public void ResetSlider()
        {
            _expSlider.ResetImage();
        }

        private void Subscribes()
        {
            _heroCardViewModel.Experience.Subscribe(OnExperienceChanged).AddTo(ref _disposables);
        }

        private void OnExperienceChanged(float experience)
        {
            _exp.text = _heroCardViewModel.ExperienceToLvlUp;
            _expSlider.SetExpValue(experience);
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}