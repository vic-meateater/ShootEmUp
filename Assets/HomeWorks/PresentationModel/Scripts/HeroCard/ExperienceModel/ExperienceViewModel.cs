using R3;

namespace Popup
{
    public sealed class ExperienceViewModel: IExperienceViewModel
    { 
        private const float MAX_EXPERIENCE = 1000f;
        private const float RESET_EXPERIENCE = 0;
        public ReadOnlyReactiveProperty<float> Experience => _experience;
        public float MaxExperience => _maxExperience;
        private readonly ReactiveProperty<float> _experience = new();
        private float _maxExperience;


        public ExperienceViewModel(HeroCardInfo heroCardInfo)
        {
            _experience.Value = heroCardInfo.Experience;
            _maxExperience = MAX_EXPERIENCE;
        }
        public void AddExperience(float value)
        {
            if (_experience.Value + value <= _maxExperience)
                _experience.Value += value;
            else
                _experience.Value = _maxExperience;
        }

        public void ResetExperience()
        {
            _experience.Value = RESET_EXPERIENCE;
        }

        public void SetMaxExperience(float value)
        {
            _maxExperience = value;
        }
    }
}