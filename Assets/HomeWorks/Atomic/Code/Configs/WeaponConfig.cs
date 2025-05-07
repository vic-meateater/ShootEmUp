using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "ZombieGame/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}