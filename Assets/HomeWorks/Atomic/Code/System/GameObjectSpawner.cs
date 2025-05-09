using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameObjectSpawner : MonoBehaviour
    {
        public GameObject SpawnedGO => _spawnedGo;

        private GameObject _spawnedGo;
        public void SpawnGameObject(GameObject prefab, Transform spawnPoint, Transform parent)
        {
            _spawnedGo = Instantiate(
                prefab,
                spawnPoint.position,
                Quaternion.identity, // подумать про rotation
                parent.transform);
        }
    }
}