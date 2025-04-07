using R3;
using UnityEngine;

namespace Popup
{
    public class CharacterInfoViewModel: ICharacterInfoViewModel
    {
        public ReadOnlyReactiveProperty<string> Title => _title;
        public ReadOnlyReactiveProperty<Sprite> Avatar => _avatar;
        public ReadOnlyReactiveProperty<string> Description => _description;
        
        private ReactiveProperty<string> _title;
        private ReactiveProperty<Sprite> _avatar;
        private ReactiveProperty<string> _description;

        public CharacterInfoViewModel(HeroCardInfo config)
        {
            _title = new ReactiveProperty<string>(config.Title);
            _avatar = new ReactiveProperty<Sprite>(config.Avatar);
            _description = new ReactiveProperty<string>(config.Description);
        }

        public void SetTitle(string title)
        {
            _title.Value = title;
        }

        public void SetAvatar(Sprite avatar)
        {
            _avatar.Value = avatar;
        }

        public void SetDescription(string description)
        {
            _description.Value = description;
        }
    }
}