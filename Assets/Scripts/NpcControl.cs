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

    // Start is called before the first frame update
    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].transform.position);

        if (GlobalVariables.Instance != null)
        {
            navAgent.speed = GlobalVariables.Instance.speed*navAgent.speed*GlobalVariables.Instance.difficulty;
            speed0 = navAgent.speed;
        }
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && gameObject.CompareTag("AI"))
        {
            other.gameObject.SetActive(false);
            float random = Random.Range(0.0f, 3.0f);

            if (random < 1)
            {
                navAgent.speed = speed0 * 2;
            }
            else if (random > 2)
            {
                navAgent.speed = speed0 / 2;
            }
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
        else if (other.gameObject.CompareTag("Finish") && gameObject.CompareTag("AI"))
        {
            if (other.transform == checkpoints[check].transform)
            {
                check++;
            }
            if (check == 3)
            {
                GlobalVariables.Instance.win = false;
                SceneManager.LoadScene("End");
            }
        }
    }
}
