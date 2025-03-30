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
        // [NonSerialized] public Transform WorldTransform;
        // [NonSerialized] public LevelBounds LevelBounds;
        [NonSerialized] public Player Player;
        
        // [Header("Enemy")]
        // [NonSerialized] public GameObject EnemyPrefab;
        // [NonSerialized] public Transform EnemyPoolContainerTransform;
        // [NonSerialized] public EnemyPositions EnemyPositions;
        
        [Header("Bullet")]
        [NonSerialized] public Bullet BulletPrefab;
        [NonSerialized] public Transform BulletPoolContainerTransform;
        [NonSerialized] public int BulletInitialCount;

    }
}