using R3;

namespace Popup
{
    public interface IExperienceViewModel: IViewModel
    {
        ReadOnlyReactiveProperty<float> Experience { get; }
        public float MaxExperience { get; }
        public void AddExperience(float value);
        public void ResetExperience();
        public void SetMaxExperience(float value);
    }
}