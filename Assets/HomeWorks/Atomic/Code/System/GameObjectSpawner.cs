using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameObjectSpawner : MonoBehaviour
    {
        private GameObject _spawnedGo;
        public GameObject SpawnGameObject(GameObject prefab, Transform spawnPoint, Transform parent)
        {
            _spawnedGo = Instantiate(
                prefab,
                spawnPoint.position,
                Quaternion.identity, // подумать про rotation
                parent.transform);
            return _spawnedGo;
        }
    }
}