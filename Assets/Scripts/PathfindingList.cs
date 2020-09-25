using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingList
{
private List<NodeRecord> NodeRecordList = new List<NodeRecord>();
public PathfindingList()
{
}
// Add NodeRecord.
public void AddNodeRecord(NodeRecord NodeRecord)
{
NodeRecordList.Add(NodeRecord);
}
// Remove a node from the list.
public void RemoveNodeRecord(NodeRecord NodeRecord)
{
NodeRecordList.Remove(NodeRecord);
}
// Get the size of the list.
public int GetSize()
{
return NodeRecordList.Count;
}
// Get the smallest element.
public NodeRecord GetSmallestElement()
{
NodeRecord TmpNodeRecord = new NodeRecord();
TmpNodeRecord.EstimatedTotalCost = float.MaxValue;
foreach (NodeRecord NodeRecord in NodeRecordList)
{
if(NodeRecord.EstimatedTotalCost < TmpNodeRecord.EstimatedTotalCost)
{
TmpNodeRecord = NodeRecord;
}
}
return TmpNodeRecord;
}
// Returns true if a node is contained in the list.
public bool Contains(GameObject Node)
{
foreach (NodeRecord NodeRecord in NodeRecordList)
{
if (NodeRecord.Node.Equals(Node))
{
return true;
}
}
return false;
}
// Returns a node record for a node if it is contained in the list.
public NodeRecord Find(GameObject Node)
{
foreach (NodeRecord NodeRecord in NodeRecordList)
{
if (NodeRecord.Node.Equals(Node))
{
return NodeRecord;
}
}
return null;
}
}
