using R3;
using UnityEngine;

namespace Popup
{
    public interface ICharacterInfoViewModel
    {
        ReadOnlyReactiveProperty<string> Title { get; }
        ReadOnlyReactiveProperty<Sprite> Avatar { get; }
        ReadOnlyReactiveProperty<string> Description { get; }

        public void SetTitle(string title);
        public void SetAvatar(Sprite avatar);
        public void SetDescription(string description);
    }
}