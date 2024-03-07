using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraitorWalkingState : RegularWalkingState
{
    private GameObject waypointContainer;
    private List<Transform> killWaypoints;
    private float startRoutineChance;

    public TraitorWalkingState(GameObject waypointContainer, List<Transform> killWaypoints, float startRoutineChance) : base(waypointContainer)
    {
        this.waypointContainer = waypointContainer;
        this.killWaypoints = killWaypoints;
        this.startRoutineChance = startRoutineChance;
    }

    public override void OnStateEnter(AbstractStateManager entity)
    {
        base.OnStateEnter(entity);
    }

    public override void UpdateState(AbstractStateManager entity)
    {
        base.UpdateState(entity);
    }
}