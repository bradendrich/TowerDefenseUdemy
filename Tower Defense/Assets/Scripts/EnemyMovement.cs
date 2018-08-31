using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        var currentPosition = this.transform.position;
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position + currentPosition;
            yield return new WaitForSeconds(1f);
        }
        print("Patrol Finished");
    }

    void Update ()
    {
		
	}
}
