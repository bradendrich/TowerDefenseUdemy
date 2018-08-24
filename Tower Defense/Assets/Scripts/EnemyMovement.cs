﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Patrol Finished");
    }

    void Update ()
    {
		
	}
}
