public abstract class AbstractState : State {
    public abstract void OnStateEnter(StateManager entity);
    public abstract void UpdateState(StateManager entity);
}
