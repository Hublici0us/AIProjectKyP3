using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointBehavior : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWaypoint = 0;

    public float speed = 5.0f;
    public float rotationSpeed = 10f;
    public float lookAhead = 10f;

    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead)
        {
            Quaternion lookatTracker = Quaternion.LookRotation(tracker.transform.position - transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatTracker, rotationSpeed * Time.deltaTime * 2);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
            return;
        }

        if (Vector3.Distance(tracker.transform.position, waypoints[currentWaypoint].transform.position) < 3) { currentWaypoint++; }
        if (currentWaypoint >= waypoints.Length) { currentWaypoint = 0; }

        tracker.transform.LookAt(waypoints[currentWaypoint].transform);
        tracker.transform.Translate(0, 0, (speed + 10) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();


        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

    
}
