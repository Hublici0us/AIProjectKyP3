using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    public float speed = 5.0f;
    float accuracy = 2.0f;
    public float rotSpeed = 5.0f;

    public GameObject wpManager;
    GameObject[] waypoints;
    GameObject currentNode;
    public int currentWP = 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToBase()
    {
        g.AStar(currentNode, waypoints[2]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, waypoints[4]);
        currentWP = 0;
    }

    public void GoToOilRigs()
    {
        g.AStar(currentNode, waypoints[0]);
        currentWP = 0;
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, waypoints[7]);
        currentWP = 0;
    }

    public void LateUpdate()
    {
        if(g.pathList.Count == 0 || currentWP == g.pathList.Count) { return; }

        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, this.transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }


    }
}
