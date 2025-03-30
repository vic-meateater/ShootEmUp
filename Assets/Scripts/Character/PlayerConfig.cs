using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "PlayerConfig",
        menuName = "ShootEmUp/New PlayerConfig"
    )]
    public class PlayerConfig : ScriptableObject
    {
        public Player PlayerPrefab;
        public float Speed = 5f;
        public int Health = 5;
    }
}