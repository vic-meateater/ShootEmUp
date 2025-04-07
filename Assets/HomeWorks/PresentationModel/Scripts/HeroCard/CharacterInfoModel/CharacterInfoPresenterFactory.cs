namespace Popup
{
    public sealed class CharacterInfoPresenterFactory: ICharacterInfoPresenterFactory
    {
        public CharacterInfoViewModel Create(HeroCardInfo heroCardInfo)
        {
            return new CharacterInfoViewModel(heroCardInfo);
        }
    }
}