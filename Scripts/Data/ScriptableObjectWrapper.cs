using UnityEngine;

namespace UnityBlocks.Helpers.Data
{
    public abstract class ScriptableObjectWrapper<T> : ScriptableObject
    {
        [SerializeField] private T data;

        public T Data => data;
    }
}