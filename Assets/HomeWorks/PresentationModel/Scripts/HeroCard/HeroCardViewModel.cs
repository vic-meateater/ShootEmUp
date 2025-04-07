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
        public int MoveSpeed { get; }
        public int Stamina { get; }
        public int Dexterity { get; }
        public int Intelligence { get; }
        public int Damage { get; }
        public int Regeneration { get; }
        
        public ReadOnlyReactiveProperty<bool> CanLevelUp => _levelViewModel.CanLevelUp;
        
        private HeroCardInfo _cardInfo;
        private IExperienceViewModel _experienceViewModel;
        private ILevelViewModel _levelViewModel;
        private ICharacterInfoViewModel _characterInfoViewModel;
        private DisposableBag _disposableBag;

        public HeroCardViewModel(
            HeroCardInfo info, 
            IExperienceViewModel experienceViewModel,
            ILevelViewModel levelViewModel,
            ICharacterInfoViewModel characterInfoViewModel)
        {
            
            _cardInfo = info;
            _experienceViewModel = experienceViewModel;
            _levelViewModel = levelViewModel;
            _characterInfoViewModel = characterInfoViewModel;
            
            Title = _characterInfoViewModel.Title;
            Avatar = _characterInfoViewModel.Avatar;
            Level = _levelViewModel.Level;
            Description = _characterInfoViewModel.Description;
            Experience = _experienceViewModel.Experience;
            MoveSpeed = _cardInfo.MoveSpeed;
            Stamina = _cardInfo.Stamina;
            Dexterity = _cardInfo.Dexterity;
            Intelligence = _cardInfo.Intelligence;
            Damage = _cardInfo.Damage;
            Regeneration = _cardInfo.Regeneration;
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