using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    public class DrawGizmos : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, Vector3.up * 2f, Color.red, Time.deltaTime);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 1f);
            
        }

    }
}
