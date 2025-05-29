using UnityEngine;

namespace UnityBlocks.Helpers.Data.ProbabilityGroups
{
    [CreateAssetMenu(menuName = "Unity Blocks/Data/Random Prefabs Group")]
    public class PrefabGroupConfig : RandomContentGroupConfig<GameObject>
    {
        [ContextMenu("Run Probability Simulation")]
        private void ContextTestProbability() => RunSimulation();
    }
}