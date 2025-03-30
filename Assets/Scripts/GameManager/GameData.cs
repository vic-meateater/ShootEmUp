using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "GameDataConfig",
        menuName = "ShootEmUp/GameDataConfig"
    )]
    public class GameData : ScriptableObject
    {
        [NonSerialized] public Player Player;
    }
}