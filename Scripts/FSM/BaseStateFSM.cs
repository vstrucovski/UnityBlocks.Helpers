namespace UnityBlocks.Helpers.FSM
{
    // Basic state class without any payload
    public class BaseStateFSM
    {
        protected BaseBrainFSM StateMachine { get; private set; }

        public void SetStateMachine(BaseBrainFSM fsm)
        {
            StateMachine = fsm;
        }

        public virtual void Init()
        {
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void Update()
        {
        }
    }
}