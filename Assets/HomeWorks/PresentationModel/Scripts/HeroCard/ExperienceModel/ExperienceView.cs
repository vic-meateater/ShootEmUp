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
        
        private IExperienceViewModel _experienceViewModel;
        private DisposableBag _disposables;
        
        public void Init(IExperienceViewModel experienceViewModel)
        {
            _experienceViewModel = experienceViewModel;

            Subscribes();
        }

        public void ResetSlider()
        {
            _expSlider.ResetImage();
        }

        private void Subscribes()
        {
            _experienceViewModel.Experience.Subscribe(OnExperienceChanged).AddTo(ref _disposables);
        }

        private void OnExperienceChanged(float experience)
        {
            _exp.text = _experienceViewModel.ExperienceToLvlUp;
            _expSlider.SetExpValue(experience);
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}