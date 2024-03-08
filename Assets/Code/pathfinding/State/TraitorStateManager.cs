using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraitorStateManager : AbstractStateManager
{
    [SerializeField] GameObject waypointContainer;
    [SerializeField] float velocity;
    [SerializeField] List<Transform> killWaypoints;
    [SerializeField] float startRoutineChance;

    public override void Start()
    {
        WalkingState = new TraitorWalkingState(waypointContainer, velocity, killWaypoints, startRoutineChance);
        base.Start();
    }

}
