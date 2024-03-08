using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraitorWalkingState : RegularWalkingState
{
    private List<Transform> killWaypoints;
    private float startRoutineChance;

    private int nextKillRoutineIndex = 0;
    private bool isInKillRoutine;

    public TraitorWalkingState(GameObject waypointContainer, List<Transform> killWaypoints, float startRoutineChance) : base(waypointContainer)
    {
        this.killWaypoints = killWaypoints;
        this.startRoutineChance = startRoutineChance;
    }

    protected override int nextWaypointIndex()
    {
        if (!isInKillRoutine && startRoutineChance > Random.Range(0f, 1f))
        {
            Debug.Log("Entering kill routine");
            isInKillRoutine = true;
        }
        if (isInKillRoutine)
        {
            int index = Waypoints.IndexOf(killWaypoints[nextKillRoutineIndex++]);
            if (nextKillRoutineIndex == killWaypoints.Count)
            {
                Debug.Log("Exiting kill routine");
                isInKillRoutine = false;
                nextKillRoutineIndex = 0;
            }
            return index;
        }
        return base.nextWaypointIndex();
    }
}