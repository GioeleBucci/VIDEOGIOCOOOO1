using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStateManager : MonoBehaviour
{
    public State WalkingState { get; set; }
    public GameObject WaypointContainer { get; }

    private State _busyState;

    public State BusyState
    {
        get { return _busyState; }
    }

    private State currentState;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _busyState = new BusyState();
        this.currentState = WalkingState;
        currentState.OnStateEnter(this);
    }

    // Update is called once per frame
    public void Update()
    {
        currentState.UpdateState(this);
    }

    /// <summary>
    /// Switch to a new state.
    /// </summary>
    /// <param name="newState">The new state.</param>
    public void SwitchState(State newState)
    {
        this.currentState = newState;
        newState.OnStateEnter(this);
    }
}
