/// <summary>
/// Represents an NPC's <b>state</b>.
/// </summary>
public interface State {
    /// <summary>
    /// Gets called once when state is instantiated.
    /// </summary>
    /// <param name="entity"></param>
    void OnStateEnter(StateManager entity);

    /// <summary>
    /// Gets called each frame this is the current set state.
    /// </summary>
    /// <param name="entity"></param>
    void UpdateState(StateManager entity);
}