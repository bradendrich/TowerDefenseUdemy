using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>();

    bool isRunning = true;

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
        ColorStartAndEnd();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }


    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            SearchingFromEndPoint();
            ExploreNeighbors();
        }
    }

    private void SearchingFromEndPoint()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploredNeighbor = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(exploredNeighbor))
            {
                QueueNewNeighbors(exploredNeighbor);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int exploredNeighbor)
    {
        Waypoint neighbor = grid[exploredNeighbor];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {

        }
        else
        {
            neighbor.isExplored = true;
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping waypoing " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
