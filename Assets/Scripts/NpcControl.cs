using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NpcControl : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject[] checkpoints;
    private int check = 0;
    private int counter = 0;
    private float MinDist = 4.0f;
    private NavMeshAgent navAgent;
    private Vector3 direction;
    private float speed0;

    // Initialize at the first waypoint
    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].transform.position);

        // Set speed of the NPC according to the chosen difficulty level
        if (GlobalVariables.Instance != null)
        {
            navAgent.speed = GlobalVariables.Instance.speed*navAgent.speed*GlobalVariables.Instance.difficulty;
            speed0 = navAgent.speed;
        }
    }

    // Set direction of the NPC to the next waypoint
    void Update()
    {
        direction = waypoints[counter].transform.position - this.transform.position;

        // If the NPC is close to a waypoint, go to the next waypoint
        if (direction.magnitude < MinDist && counter < waypoints.Length-1)
        {
            counter = counter + 1;
            navAgent.SetDestination(waypoints[counter].transform.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if NPC hit a collectable gameobject
        if (other.gameObject.CompareTag("PickUp") && gameObject.CompareTag("AI"))
        {
            // Deactivate the collectable
            other.gameObject.SetActive(false);
            float random = Random.Range(0.0f, 3.0f);

            // choose wich action occurs based on a random number
            // double speed
            if (random < 1)
            {
                navAgent.speed = speed0 * 2;
            }
            // half speed 
            else if (random > 2)
            {
                navAgent.speed = speed0 / 2;
            }
            // respawn 
            else if (random >= 1 && random <= 2)
            {
                GameObject[] respawns;
                navAgent.speed = speed0;
                respawns = GameObject.FindGameObjectsWithTag("Respawn");
                GameObject closest = null;
                float distance = Mathf.Infinity;
                foreach (GameObject rs in respawns)
                {
                    Vector3 diff = rs.transform.position - transform.position;
                    if (diff.sqrMagnitude < distance)
                    {
                        distance = diff.sqrMagnitude;
                        closest = rs;
                    }
                }
                transform.position = closest.transform.position;
                transform.rotation = closest.transform.rotation;
            }

        }
        // check if NPC is at a checkpoint 
        else if (other.gameObject.CompareTag("Finish") && gameObject.CompareTag("AI"))
        {
            // NPC has to go through all checkpoints befor he can pass the finish line
            if (other.transform == checkpoints[check].transform)
            {
                check++;
            }
            // set the winning variable to false if the NPC arrives first at the finish line
            if (check == 3)
            {
                GlobalVariables.Instance.win = false;
                SceneManager.LoadScene("End");
            }
        }
    }
}
