namespace UnityBlocks.Helpers.FSM
{
    public abstract class BaseStateFsmWithPayload<TCustomPayload> : BaseStateFSM
    {
        public TCustomPayload Payload;

        public virtual void OnEnter(TCustomPayload payload)
        {
            Payload = payload;
        }
    }
}