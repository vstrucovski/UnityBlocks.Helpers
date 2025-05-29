using System.Collections.Generic;
using UnityEngine;

namespace UnityBlocks.Helpers.Data
{
    public class ScriptableObjectGroup<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField] private List<T> list;

        public List<T> List => list;
    }
}