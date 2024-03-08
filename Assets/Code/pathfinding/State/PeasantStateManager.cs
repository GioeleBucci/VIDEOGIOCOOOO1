using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeasantStateManager : AbstractStateManager
{
    [SerializeField] GameObject waypointContainer;
    [SerializeField] float velocity;

    public override void Start()
    {
        WalkingState = new RegularWalkingState(waypointContainer, velocity);
        base.Start();
    }

}