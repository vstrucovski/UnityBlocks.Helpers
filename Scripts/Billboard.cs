using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class Billboard : MonoBehaviour
    {
        public Camera mainCamera;

        private void LateUpdate()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
        }
    }
}