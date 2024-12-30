using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class Billboard : MonoBehaviour
    {
        public Camera mainCamera;

        private void Start()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
        }
    }
}