using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList = new List<Edge>();
    public Node path = null;
    GameObject id;

    public float f, g, h; // g is how far you've gone so far.
    public Node cameFrom;

    public Node(GameObject i)
    {
        id = i;
        path = null;
    }

    public GameObject getId() { return id; }
}
