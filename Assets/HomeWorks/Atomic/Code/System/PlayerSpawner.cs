using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerParent;
        [SerializeField] private SceneContext _context;

        private void Start()
        {
            var playerGo = Instantiate(
                _playerPrefab,
                _playerSpawnPoint.position,
                _playerSpawnPoint.rotation,
                _playerParent.transform);
            
            var playerEntity = playerGo.GetComponent<SceneEntity>();
            
            _context.GetPlayerService().SetPlayerEntity(playerEntity);
        }
    }
}
