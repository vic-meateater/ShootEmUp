using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class PlayerSpawner : MonoBehaviour
    {
        public GameObject PlayerGO => _playerGo;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _playerParent;

        private GameObject _playerGo;
        public void SpawnPlayer(GameObject playerPrefab)
        {
            _playerGo = Instantiate(
                playerPrefab,
                _playerSpawnPoint.position,
                _playerSpawnPoint.rotation,
                _playerParent.transform);
        }
    }
}
