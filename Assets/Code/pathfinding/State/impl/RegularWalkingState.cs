using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RegularWalkingState : AbstractState
{
    private const float velocity = 2f;
    private const float THRESHOLD = 2f;
    private List<Transform> _waypoints;
    public List<Transform> Waypoints
    {
        get { return _waypoints; }
    }
    private AbstractStateManager entity;
    private int currentWaypointIndex;

    public RegularWalkingState(GameObject waypointContainer)
    {
        _waypoints = waypointContainer.GetComponentsInChildren<Transform>(false).ToList();
        if (_waypoints == null || _waypoints.Count == 0)
        {
            throw new ArgumentException("No waypoints container set or the container has no children.");
        }
    }

    public override void OnStateEnter(AbstractStateManager entity)
    {
        this.entity = entity;
        NextWaypoint();
    }

    public override void UpdateState(AbstractStateManager entity)
    {
        if (IsAtWaypoint())
        {
            entity.SwitchState(entity.BusyState);
        }
        var targetPosition = _waypoints[currentWaypointIndex].position;
        entity.transform.position = Vector2.MoveTowards(entity.transform.position,
            targetPosition,
            velocity * Time.deltaTime);
    }

    private bool IsAtWaypoint()
    {
        return Vector2.Distance(entity.transform.position, _waypoints[currentWaypointIndex].position) < THRESHOLD;
    }

    private void NextWaypoint()
    {
        int next;
        int counter = 0;
        do
        {
            next = nextWaypointIndex();
            counter++;
            if (counter == 10)
            {
                Debug.LogError("INFINITE LOOP");
                break;
            }
        } while (next == currentWaypointIndex);
        currentWaypointIndex = next;
    }

    /// <summary>
    /// Picks the next waypoint index. By default a random waypoint is picked.
    /// </summary>
    /// <returns>the index of the next waypoint</returns>
    protected virtual int nextWaypointIndex()
    {
        return UnityEngine.Random.Range(0, _waypoints.Count);
    }

}