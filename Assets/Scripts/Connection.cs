using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{private float Cost = 0;
private GameObject FromNode;
private GameObject ToNode;
public Connection()
{
}
public float GetCost()
{
if(Cost == 0)
{
Cost = Vector3.Distance(FromNode.transform.position, ToNode.transform.position);
}
return Cost;
}
public GameObject GetFromNode()
{
return FromNode;
}
public void SetFromNode(GameObject FromNode)
{
this.FromNode = FromNode;
Cost = 0;
}
public GameObject GetToNode()
{
return ToNode;
}
public void SetToNode(GameObject ToNode)
{
this.ToNode = ToNode;
Cost = 0;
}
}
