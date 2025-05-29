using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace UnityBlocks.Helpers.Data.RandomizedList
{
    public abstract class RandomContentGroupConfig<T> : ScriptableObject where T : Object
    {
        [SerializeField] protected List<WeightedListItem<T>> items;

        public List<WeightedListItem<T>> Items => items;

        public T GetRandomItem()
        {
            var totalWeight = items.Sum(x => x.probability);
            var roll = Random.value * totalWeight;
            var cumulative = 0f;

            foreach (var obj in items)
            {
                cumulative += obj.probability;
                if (roll <= cumulative)
                    return obj.item;
            }

            return items.Count > 0 ? items[Random.Range(0, items.Count)].item : null;
        }

        private Dictionary<string, int> Simulate(int count)
        {
            var results = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                var item = GetRandomItem();
                var name = item != null ? item.name : "NULL";

                if (!results.ContainsKey(name))
                    results[name] = 0;

                results[name]++;
            }

            return results;
        } 
        
        public void RunSimulation()
        {
            var logEntries = Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
            var clearMethod = logEntries?.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
            clearMethod?.Invoke(null, null);
            var results = Simulate(10000);
            Debug.Log("=== Random Group Test ===");
            foreach (var kvp in results.OrderBy(x => x.Key))
                Debug.Log($"{kvp.Key}: {kvp.Value} hits ({(kvp.Value / 100f):F2}%)");
        }
    }
}