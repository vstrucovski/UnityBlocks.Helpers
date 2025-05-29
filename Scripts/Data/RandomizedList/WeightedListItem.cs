using System;
using UnityEngine;

namespace UnityBlocks.Helpers.Data.RandomizedList
{
    [Serializable]
    public class WeightedListItem<T> where T : UnityEngine.Object
    {
        public T item;

        [Range(0, 1)]
        public float probability = 1f;
    }
}