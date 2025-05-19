using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    public class GameData : MonoBehaviour
    {
        [field: SerializeField] public UnitConfig RedCube;
        [field: SerializeField] public UnitConfig BlueCube;
        [field: SerializeField] public GameObject RedParent;
        [field: SerializeField] public GameObject BlueParent;
        // public Vector3 RedArmyStartPosition = new Vector3(-50, 0, 0);
        // public Vector3 BlueArmyStartPosition = new Vector3(50, 0, 0);
        public float UnitsSpacing = 2f;
    }
}