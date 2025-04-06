using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Popup
{
    public class LevelUpButton : MonoBehaviour
    {
        public Button Button => _button;
        
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _availableButtonSprite;
        [SerializeField] private Sprite _lockedButtonSprite;
        [Space]
        [SerializeField] private LevelUpButtonState _state;
        
        public void AddListener(UnityAction action)
        {
            Button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }
        
        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? LevelUpButtonState.Available : LevelUpButtonState.Locked;
            SetState(state);
        }
        
        private void SetState(LevelUpButtonState state)
        {
            _state = state;

            switch (state)
            {
                case LevelUpButtonState.Available:
                    Button.interactable = true;
                    _button.image.sprite = _availableButtonSprite;
                    break;
                case LevelUpButtonState.Locked:
                    Button.interactable = false;
                    _button.image.sprite = _lockedButtonSprite;
                    break;
                default:
                    throw new Exception($"Undefined button state {state}!");
            }
        }
    }
}
