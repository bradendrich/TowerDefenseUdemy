using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform MoveToPan;
    [SerializeField] Transform TargetEnemy;

	void Update ()
    {
        transform.LookAt(MoveToPan);
        transform.LookAt(TargetEnemy);
	}
}
