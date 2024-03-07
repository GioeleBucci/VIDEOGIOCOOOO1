using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeasantStateManager : AbstractStateManager
{
    public override void Start()
    {   
        Debug.Log("1");
        base.Start();
    }

    public PeasantStateManager()
    {
        base.WalkingState = new RegularWalkingState(base.WaypointContainer);
    }
}