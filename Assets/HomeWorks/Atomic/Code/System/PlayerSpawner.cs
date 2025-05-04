using System;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerParent;

        private void Start()
        {
            Instantiate(
                _playerPrefab,
                _playerSpawnPoint.position,
                _playerSpawnPoint.rotation,
                _playerParent.transform);
        }
    }
}
