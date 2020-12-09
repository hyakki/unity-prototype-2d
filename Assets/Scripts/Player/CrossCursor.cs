using UnityEngine;
using UnityEngine.InputSystem;

public class CrossCursor : MonoBehaviour
{
    public float radius = 5f;
    public Vector3 direction = Vector3.zero;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
