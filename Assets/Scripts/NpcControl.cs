using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    public GameObject[] waypoints;
    private int counter = 0;
    private float MinDist = 4.0f;
    private NavMeshAgent navAgent;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        direction = waypoints[counter].transform.position - this.transform.position;

        if (direction.magnitude < MinDist && counter < waypoints.Length-1)
        {
            counter = counter + 1;
            navAgent.SetDestination(waypoints[counter].transform.position);
        }
    }
}
