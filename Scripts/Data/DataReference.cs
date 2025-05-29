using UnityEngine;

namespace UnityBlocks.Helpers.Data
{
    public abstract class DataReference<T> : ScriptableObject
    {
        // ⚠️ Make sure T is serializable or Unity will silently ignore it
        [SerializeField] private T data;

        public T Data => data;
    }
}