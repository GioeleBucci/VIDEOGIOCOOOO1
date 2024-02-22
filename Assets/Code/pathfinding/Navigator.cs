using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Navigator : MonoBehaviour {
    private const float THRESHOLD = 2f;
    [SerializeField] private float velocity = 2f;
    [SerializeField] private GameObject waypointContainer;
    private List<Transform> waypoints;
    private int currentWaypointIndex;


    // Start is called before the first frame update
    void Start() {
        // take all transforms in children and store them in a waypoints list
        waypoints = waypointContainer.GetComponentsInChildren<Transform>(false).ToList();
        if (waypoints == null || waypoints.Count == 0) { 
            Debug.LogError("No waypoints set or the list is empty. Please set the list of waypoints.");
            Application.Quit();
        }
        NextWaypoint();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(waypoints.Count);
        var targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, velocity * Time.deltaTime);
        if (IsAtWaypoint()) {
            NextWaypoint();
        }
    }

    bool IsAtWaypoint() {
        return Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < THRESHOLD;
    }

    void NextWaypoint() { 
        int next;
        do {
            next = Random.Range(0, waypoints.Count);
        } while (next == currentWaypointIndex);
        currentWaypointIndex = next;
    }

}
