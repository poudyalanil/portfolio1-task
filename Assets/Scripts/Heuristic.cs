using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heuristic
{
public Heuristic()
{
}
public float Estimate(GameObject StartNode, GameObject GoalNode)
{
return Vector3.Distance(StartNode.transform.position, GoalNode.transform.position);
}
}
