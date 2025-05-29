using UnityEngine;

namespace UnityBlocks.Helpers.Data.RandomizedList
{
    [CreateAssetMenu(menuName = "Unity Blocks/Data/Random Prefabs Group")]
    public class PrefabGroupConfig : RandomContentGroupConfig<GameObject>
    {
        [ContextMenu("Run Probability Simulation")]
        private void ContextTestProbability() => RunSimulation();
    }
}