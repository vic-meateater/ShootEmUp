using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ZombieGame/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public WeaponConfig Weapon { get; private set; }
        [field: SerializeField] public BulletConfig Bullet { get; private set; }
        
    }
}
