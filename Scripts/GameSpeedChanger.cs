using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class GameSpeedChanger : MonoBehaviour
    {
        [SerializeField]
        // ReSharper disable once NotAccessedField.Local
        private string about = "F1-F6 change game speed@";

        private static void SetFPS(int value)
        {
            Application.targetFrameRate = 60;
            Time.timeScale = value / 60f;
            Debug.Log($"FPS changed: {value}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                SetFPS(1);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                SetFPS(5);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                SetFPS(10);
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                SetFPS(30);
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                SetFPS(60);
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                SetFPS(120);
            }
        }
    }
}