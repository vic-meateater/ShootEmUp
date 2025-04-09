using UnityEngine;
using UnityEngine.UI;

namespace Popup
{
    public class ExpSlider : MonoBehaviour
    {
        [SerializeField] private  Slider _slider;
        [SerializeField] private  Image _sourceImage;
        [SerializeField] private Sprite _filledImage;
        [SerializeField] private Sprite _unFilledImage;

        public void SetExpValue(float value)
        {
            _slider.value = value;
            if (Mathf.Approximately(_slider.value, _slider.maxValue))
            {
               _sourceImage.sprite =  _filledImage;
            }
        }

        public void RestImage()
        {
            _sourceImage.sprite = _unFilledImage;
        }
    }
}
