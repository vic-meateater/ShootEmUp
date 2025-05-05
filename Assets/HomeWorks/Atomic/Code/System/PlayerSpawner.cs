using System;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerParent;
        [SerializeField] private PlayerService _playerService;

        private void Start()
        {
            var player = Instantiate(
                _playerPrefab,
                _playerSpawnPoint.position,
                _playerSpawnPoint.rotation,
                _playerParent.transform);
            _playerService.SetPlayerEntity(player.GetComponent<SceneEntity>());
        }
    }
}
