using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    // Update is called once per frame
    void Start()
    {
        PrintAllWaypoints();
    }

    private void PrintAllWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            print(waypoint);
        }
    }

    void Update ()
    {
		
	}
}
