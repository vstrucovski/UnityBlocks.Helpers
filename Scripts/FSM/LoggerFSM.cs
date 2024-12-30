using System;
using UnityEngine;

namespace UnityBlocks.Helpers.FSM
{
    public class LoggerFSM : MonoBehaviour
    {
        [SerializeField, Multiline(10)] private string output = "";
        private BaseBrainFSM _fsm;

        public void Init(BaseBrainFSM fsm)
        {
            _fsm = fsm;
            _fsm.OnEnter += OnEnterState;
        }

        private void OnEnterState(BaseStateFSM obj)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            output = $"{time}:{obj.GetType().Name}\n{output}";
        }

        [ContextMenu("Clear")]
        private void Clear()
        {
            output = "";
        }
    }
}