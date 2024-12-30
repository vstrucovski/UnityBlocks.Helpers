using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class ChildArranger : MonoBehaviour
    {
        [SerializeField] private float horizontalSpacing = 4.3f;
        [SerializeField] private float verticalSpacing = 4f;
        [SerializeField] private int numberOfColumns = 1;
        public Vector3 rotateAxis = Vector3.right;
        public float rotatePower = 25;

        [ContextMenu("Arrange Children")]
        // ReSharper disable once UnusedMember.Local
        public void ArrangeChildren()
        {
            var numberOfRows = Mathf.CeilToInt((float) transform.childCount / numberOfColumns);
            var startPosition = new Vector3(-(numberOfColumns - 1) * horizontalSpacing / 2,
                0f, (numberOfRows - 1) * verticalSpacing / 2);

            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var row = i / numberOfColumns;
                var column = i % numberOfColumns;

                var position = new Vector3(startPosition.x + column * horizontalSpacing, 0f,
                    startPosition.y - row * verticalSpacing);
                child.localPosition = position;
            }
        }

        [ContextMenu("Rotation Noise")]
        public void RotationNoise()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var angle = Random.Range(-rotatePower, rotatePower);
                child.Rotate(rotateAxis, angle);
            }
        }
    }
}