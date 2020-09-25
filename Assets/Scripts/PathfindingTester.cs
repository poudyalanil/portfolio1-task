using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTester : MonoBehaviour
{
// The A* manager.
private AStarManager AStarManager = new AStarManager();
// Array of possible waypoints.
List<GameObject> Waypoints = new List<GameObject>();
// Array of waypoint map connections. Represents a path.
List<Connection> ConnectionArray = new List<Connection>();
// The start and end target point.
public GameObject start;
public GameObject end;
// Debug line offset.
Vector3 OffSet = new Vector3(0, 0.3f, 0);

// Start is called before the first frame update
void Start()
{
if (start == null || end == null)
{
Debug.Log("No start or end waypoints.");
return;
}
// Find all the waypoints in the level.
GameObject[] GameObjectsWithWaypointTag;
GameObjectsWithWaypointTag = GameObject.FindGameObjectsWithTag("Waypoint");
foreach (GameObject waypoint in GameObjectsWithWaypointTag)
{
WaypointCON tmpWaypointCon = waypoint.GetComponent<WaypointCON>();
if (tmpWaypointCon)
{
Waypoints.Add(waypoint);
}
}
// Go through the waypoints and create connections.
foreach (GameObject waypoint in Waypoints)
{
WaypointCON tmpWaypointCon = waypoint.GetComponent<WaypointCON>();
// Loop through a waypoints connections.
foreach (GameObject WaypointConNode in tmpWaypointCon.Connections)
{
Connection aConnection = new Connection();
aConnection.SetFromNode(waypoint);
aConnection.SetToNode(WaypointConNode);
AStarManager.AddConnection(aConnection);
}
}
// Run A Star...
ConnectionArray = AStarManager.PathfindAStar(start, end);
}
// Draws debug objects in the editor and during editor play (if option set).
void OnDrawGizmos()
{
// Draw path.
foreach (Connection aConnection in ConnectionArray)
{
Gizmos.color = Color.white;
Gizmos.DrawLine((aConnection.GetFromNode().transform.position + OffSet),
(aConnection.GetToNode().transform.position + OffSet));
}
}
// Update is called once per frame
void Update()
{
}
}