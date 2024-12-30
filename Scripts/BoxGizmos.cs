using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class BoxGizmos : MonoBehaviour
    {
        [SerializeField] private Vector3 size;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}