public abstract class AbstractState : State
{
    public abstract void OnStateEnter(AbstractStateManager entity);
    public abstract void UpdateState(AbstractStateManager entity);
}
