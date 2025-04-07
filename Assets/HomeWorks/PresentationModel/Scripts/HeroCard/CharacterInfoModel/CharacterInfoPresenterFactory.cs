namespace Popup
{
    public class CharacterInfoPresenterFactory: ICharacterInfoPresenterFactory
    {
        public CharacterInfoViewModel Create(HeroCardInfo heroCardInfo)
        {
            return new CharacterInfoViewModel(heroCardInfo);
        }
    }
}