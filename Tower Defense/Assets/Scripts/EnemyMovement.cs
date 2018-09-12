using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] Transform offsetPosition;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position + new Vector3(0, 0, 5);
            yield return new WaitForSeconds(1f);
        }
        print("Patrol Finished");
    }

    void Update ()
    {
		
	}
}
