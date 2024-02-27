using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    private State currentState;
    [SerializeField] private GameObject waypointContainer;
    private State walkingState;
    private State busyState;

    public State WalkingState => walkingState;
    public State BusyState => busyState;

    // Start is called before the first frame update
    void Start() {
        this.walkingState = new WalkingState(waypointContainer);
        this.busyState = new BusyState();
        this.currentState = walkingState;
        currentState.OnStateEnter(this);
    }

    // Update is called once per frame
    void Update() {
        currentState.UpdateState(this);
    }

    /// <summary>
    /// Switch to a new state.
    /// </summary>
    /// <param name="newState">The new state.</param>
    public void SwitchState(State newState) {
        this.currentState = newState;
        newState.OnStateEnter(this);
    }
}
