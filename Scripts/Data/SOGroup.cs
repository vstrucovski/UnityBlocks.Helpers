using System.Collections.Generic;
using UnityEngine;

namespace UnityBlocks.Helpers.Data
{
    public class SOGroup<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField] private List<T> list;

        public List<T> List => list;
    }
}