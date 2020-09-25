using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCON : MonoBehaviour
{// List of all connections for the node.
public List<GameObject> Connections = new List<GameObject>();
public enum waypointPropsList { Standard, Goal };
public waypointPropsList WaypointType = waypointPropsList.Standard;
private bool ObjectSelected = false;
private Vector3 NoOffSet = new Vector3(0,0,0);
private Vector3 UpOffSet = new Vector3(0, 0.1f, 0);
// Start is called before the first frame update
void Start()
{
}
// Update is called once per frame
void Update()
{
}
// Draws debug objects in the editor and during editor play (if option set).
void OnDrawGizmos()
{
if (ObjectSelected)
{
DrawWaypoint(Color.red, Color.magenta, UpOffSet);
}
else
{
DrawWaypoint(Color.yellow, Color.blue, NoOffSet);
}
ObjectSelected = false;
}
// Draws debug objects when an object is selected.
void OnDrawGizmosSelected()
{
ObjectSelected = true;
}
// Function to draw debug objects.
private void DrawWaypoint(Color WaypointColor, Color ConnectionsColor, Vector3 OffSet)
{
// Draw a yellow sphere at the transform's position
Gizmos.color = WaypointColor;
Gizmos.DrawSphere(transform.position, 0.2f);
for (int i = 0; i < Connections.Count; i++)
{
if (Connections[i] != null)
{
Gizmos.color = ConnectionsColor;
Gizmos.DrawLine((transform.position + OffSet), (Connections[i].transform.position +
OffSet));
}
}
}
}
