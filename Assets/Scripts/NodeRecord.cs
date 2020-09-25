using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRecord
{
public GameObject Node;
public Connection Connection;
public float CostSoFar;
public float EstimatedTotalCost;
public NodeRecord()
{
}
}