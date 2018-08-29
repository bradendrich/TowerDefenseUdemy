﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    bool isRunning = true;
    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        FindingPath();
        //ExploreNeighbors();
    }

    private void FindingPath()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter); //ToDo remove log
            SearchingFromEndPoint(searchCenter);
        }
        print("Finished Pathfinding?");
    }

    private void SearchingFromEndPoint(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("You found the endpoint, stopping search"); //Todo Remove Log
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploredNeighbor = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[exploredNeighbor].SetTopColor(Color.blue);
                print("Exploring Block: " + exploredNeighbor);
            }
            catch
            {
                continue;
            }
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
