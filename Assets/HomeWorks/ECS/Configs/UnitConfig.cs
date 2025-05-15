using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "ECSGame/UnitConfig")]
    public class UnitConfig : ScriptableObject
    {
        GameObject _unitPrefab;
    }
}
