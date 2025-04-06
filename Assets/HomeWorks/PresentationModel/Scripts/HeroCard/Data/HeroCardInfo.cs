using UnityEngine;

namespace Popup
{
    [CreateAssetMenu(fileName = "HeroCardInfo", menuName = "HeroCardPopup/HeroCardInfo")]
    public class HeroCardInfo : ScriptableObject
    {
        [field: Header("Character info")]
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Sprite Avatar { get; private set; }
        [field: SerializeField] public int Level { get; private set; }
        [SerializeField] [TextArea(3, 5)] private string _description;
        [field: SerializeField] public float Experience { get; private set; }
        
        [field: Header("Character stats")]
        [field: SerializeField] public int MoveSpeed { get; private set; }
        [field: SerializeField] public int Stamina { get; private set; }
        [field: SerializeField] public int Dexterity { get; private set; }
        [field: SerializeField] public int Intelligence { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int Regeneration { get; private set; }

        public string Description => _description;
    }
}
