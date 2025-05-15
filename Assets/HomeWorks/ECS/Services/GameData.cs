using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS.Services
{
    public class GameData : MonoBehaviour
    {
        [field: SerializeField] UnitConfig RedCube;
        [field: SerializeField] UnitConfig BlueCube;
        public Vector3 RedArmyStartPosition = new Vector3(-50, 0, 0);
        public Vector3 BlueArmyStartPosition = new Vector3(50, 0, 0);
        public float UnitsSpacing = 2f;
    }
}