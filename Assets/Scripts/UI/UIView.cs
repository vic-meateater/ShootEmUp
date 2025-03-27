using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIView : MonoBehaviour
    {
        [field: SerializeField] public Button PlayButton { get; private set;}
        [field: SerializeField] public Button PauseButton { get; private set;}
        [field: SerializeField] public Button ResumeButton { get; private set;}
        [field: SerializeField] public Button EndGameButton { get; private set;}
        [field: SerializeField] public TMP_Text Countdown { get; private set;}
    }
}