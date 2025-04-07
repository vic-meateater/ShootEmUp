using System;
using R3;
using UnityEngine;

namespace Popup
{
    public sealed class HeroCardViewModel: IHeroCardViewModel, IDisposable
    {
        public ReadOnlyReactiveProperty<string> Title { get; }
        public ReadOnlyReactiveProperty<Sprite> Avatar { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        public ReadOnlyReactiveProperty<string> Description { get; }
        public ReadOnlyReactiveProperty<float> Experience { get; }
        public ReadOnlyReactiveProperty<int> MoveSpeed { get; }
        public ReadOnlyReactiveProperty<int> Stamina { get; }
        public ReadOnlyReactiveProperty<int> Dexterity { get; }
        public ReadOnlyReactiveProperty<int> Intelligence { get; }
        public ReadOnlyReactiveProperty<int> Damage { get; }
        public ReadOnlyReactiveProperty<int> Regeneration { get; }
        public ReadOnlyReactiveProperty<bool> CanLevelUp => _levelViewModel.CanLevelUp;
        
        private HeroCardInfo _cardInfo;
        private IExperienceViewModel _experienceViewModel;
        private ILevelViewModel _levelViewModel;
        private ICharacterInfoViewModel _characterInfoViewModel;
        private IStatsViewModel _statsViewModel;
        
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
            
            Title = _characterInfoViewModel.Title;
            Avatar = _characterInfoViewModel.Avatar;
            Level = _levelViewModel.Level;
            Description = _characterInfoViewModel.Description;
            Experience = _experienceViewModel.Experience;
            MoveSpeed = _statsViewModel.MoveSpeed;
            Stamina = _statsViewModel.Stamina;
            Dexterity = _statsViewModel.Dexterity;
            Intelligence = _statsViewModel.Intelligence;
            Damage = _statsViewModel.Damage;
            Regeneration = _statsViewModel.Regeneration;
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

        public void Dispose()
        {
            _disposableBag.Dispose();
        }

        public void SetAvatar(Sprite avatar)
        {
            _characterInfoViewModel.SetAvatar(avatar);
        }
    }
}