using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "ECSGame/UnitConfig")]
    public class UnitConfig : ScriptableObject
    {
        [field: SerializeField] public Entity UnitPrefab;
        [field: SerializeField] public Team Team;
        [field: SerializeField] public int Health;
        [field: SerializeField] public  float AttackRange;
        [field: SerializeField] public  float AttackCooldown;
    }
}