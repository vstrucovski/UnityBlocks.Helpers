using NaughtyAttributes;
using UnityEngine;

namespace UnityBlocks.Helpers
{
    public class ChildArranger : MonoBehaviour
    {
        [OnValueChanged("ArrangeChildren")] public float horizontalSpacing = 4.3f;
        [OnValueChanged("ArrangeChildren")] public float verticalSpacing = 4f;
        [OnValueChanged("ArrangeChildren")] public int numberOfColumns = 1;
        [OnValueChanged("ArrangeChildren")] public Vector3 rotateAxis = Vector3.right;
        [OnValueChanged("ArrangeChildren")] public float rotatePower = 25;

        [Button]
        [ContextMenu("ArrangeChildren")]
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

        [Button]
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