using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace UnityBlocks.Helpers.Data
{
    public class SOGroup<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField, Expandable] private List<T> list;

        public List<T> List => list;
    }
}