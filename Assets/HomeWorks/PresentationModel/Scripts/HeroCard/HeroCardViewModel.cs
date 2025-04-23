using System;
using R3;
using UnityEngine;

namespace Popup
{
    public sealed class HeroCardViewModel: IHeroCardViewModel, IDisposable
    {
        public ICharacterInfoViewModel CharacterInfoViewModel => _characterInfoViewModel;
        public ILevelViewModel LevelViewModel => _levelViewModel;
        public IExperienceViewModel ExperienceViewModel => _experienceViewModel;
        public IStatsViewModel StatsViewModel => _statsViewModel;
        
        private readonly HeroCardInfo _cardInfo;
        private readonly IExperienceViewModel _experienceViewModel;
        private readonly ILevelViewModel _levelViewModel;
        private readonly ICharacterInfoViewModel _characterInfoViewModel;
        private readonly IStatsViewModel _statsViewModel;
        
        private DisposableBag _disposableBag;

        public HeroCardViewModel(
            HeroCardInfo info, 
            IExperienceViewModel experienceViewModel,
            ILevelViewModel levelViewModel,
            ICharacterInfoViewModel characterInfoViewModel,
            IStatsViewModel statsViewModel)
        {
            
            _cardInfo = info;
            _experienceViewModel = experienceViewModel;
            _levelViewModel = levelViewModel;
            _characterInfoViewModel = characterInfoViewModel;
            _statsViewModel = statsViewModel;
        }

        public void AddExp(float exp)
        {
            _experienceViewModel.AddExperience(exp);
        }

        public void LevelUp()
        {
            _levelViewModel.AddLevel();
            _experienceViewModel.ResetExperience();
        }
        
        public void SetAvatar(Sprite avatar)
        {
            _characterInfoViewModel.SetAvatar(avatar);
        }
        public void Dispose()
        {
            _disposableBag.Dispose();
        }
    }
}