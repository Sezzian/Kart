using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private float PlayerSpeed = 1;
    private float SpeedOffset = 0.1f;

    private float Speed;
    private GameObject[] respawns;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpeed = GlobalVariables.Instance.speed;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Speed = PlayerSpeed * SpeedOffset;

        Vector3 velocity = new Vector3(0.0f, 0.0f, Speed*moveVertical);
        Vector3 rotation = new Vector3(0.0f, moveHorizontal, 0.0f);

        if (moveVertical == 0f) {
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (moveVertical < 0) {
            rotation.y = -rotation.y;
        }

        transform.Translate(velocity);
        transform.Rotate(rotation);

        // Respawn the Kart at the nearest spawn point
        if (Input.GetButtonDown("Jump")) {
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
}
