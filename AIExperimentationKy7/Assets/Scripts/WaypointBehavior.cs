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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 3) { currentWaypoint++; }
        if (currentWaypoint >= waypoints.Length) { currentWaypoint = 0; }



        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - transform.position);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    
}
