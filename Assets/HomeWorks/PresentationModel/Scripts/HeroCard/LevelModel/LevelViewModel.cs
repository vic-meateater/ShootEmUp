using System;
using R3;
using UnityEngine.UI;

namespace Popup
{
    public sealed class LevelViewModel : ILevelViewModel, IDisposable
    {
        public ReadOnlyReactiveProperty<int> Level => _level;
        private readonly ReactiveProperty<int> _level = new();
        public ReadOnlyReactiveProperty<bool> CanLevelUp => _canLevelUp;
        private readonly ReactiveProperty<bool> _canLevelUp = new ReactiveProperty<bool>(false);

        private readonly HeroCardInfo _heroCardInfo;
        private readonly IExperienceViewModel _experienceViewModel;
        private readonly Button _levelUpButton;
        private DisposableBag _disposables = new();

        public LevelViewModel(HeroCardInfo heroCardInfo, IExperienceViewModel experienceViewModel)
        {
            _heroCardInfo = heroCardInfo;
            _experienceViewModel = experienceViewModel;
            
            _level.Value = _heroCardInfo.Level;
            _experienceViewModel.Experience.Subscribe(CheckExp);//.AddTo(_disposables);
        }

        public void AddLevel()
        {
            _level.Value++;
        }

        private void CheckExp(float experience)
        {
            _canLevelUp.Value = experience >= _experienceViewModel.MaxExperience;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}