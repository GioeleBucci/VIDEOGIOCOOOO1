using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkingState : AbstractState {

    private const float velocity = 2f;
    private const float THRESHOLD = 2f;
    private List<Transform> waypoints;
    private StateManager entity;
    private int currentWaypointIndex;

    public WalkingState(GameObject waypointContainer) {
        waypoints = waypointContainer.GetComponentsInChildren<Transform>(false).ToList();
        if (waypoints == null || waypoints.Count == 0) {
            throw new ArgumentException("No waypoints container set or the container has no children.");
        }
    }

    public override void OnStateEnter(StateManager entity) {
        this.entity = entity;
        NextWaypoint();
    }

    public override void UpdateState(StateManager entity) {
        if (IsAtWaypoint()) {
            entity.SwitchState(entity.BusyState);
        }
        var targetPosition = waypoints[currentWaypointIndex].position;
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, 
            targetPosition, 
            velocity * Time.deltaTime);
    }

    private bool IsAtWaypoint() {
        return Vector2.Distance(entity.transform.position, waypoints[currentWaypointIndex].position) < THRESHOLD;
    }

    private void NextWaypoint() {
        int next;
        do {
            next = UnityEngine.Random.Range(0, waypoints.Count);
        } while (next == currentWaypointIndex);
        currentWaypointIndex = next;
    }

}