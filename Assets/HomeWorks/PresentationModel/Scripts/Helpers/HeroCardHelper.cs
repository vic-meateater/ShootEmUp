using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Popup
{
    public sealed class HeroCardHelper : MonoBehaviour
    {
        [SerializeField] private HeroCardPopupView _cardPopupView;
        [SerializeField] private HeroCardInfo _cardInfo;
        [SerializeField] private float _expAmount;
        
        private HeroCardPresenterFactory _heroCardPresenterFactory;
        private HeroCardViewModel _experienceViewModel;

        [Inject]
        private void Construct(HeroCardPresenterFactory heroCardPresenterFactory)
        {
            _heroCardPresenterFactory = heroCardPresenterFactory;

        }
        
        [Button]
        public void HeroCardPopupShow()
        {
            _experienceViewModel = _heroCardPresenterFactory.Create(_cardInfo);
            _cardPopupView.Show(_experienceViewModel);
        }

        [Button]
        public void AddExp()
        {
            _experienceViewModel.AddExp(_expAmount);
        }
    }
}
