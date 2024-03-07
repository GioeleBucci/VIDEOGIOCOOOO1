using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TraitorStateManager : AbstractStateManager
{

    [SerializeField] GameObject waypointContainer;
    [SerializeField] List<Transform> killWaypoints;
    [SerializeField] private float startRoutineChance; // = 0.3f;

    public override void Start()
    {
        WalkingState = new TraitorWalkingState(waypointContainer, killWaypoints, startRoutineChance);
        base.Start();
    }

}
