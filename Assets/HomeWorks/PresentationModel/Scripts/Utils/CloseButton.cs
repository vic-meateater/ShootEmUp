using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Popup
{
    public class CloseButton : MonoBehaviour
    {
        public Button Button => _closeButton;
        
        [SerializeField] private Button _closeButton;
        
        public void AddListener(UnityAction action)
        {
            Button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }
    }
}
