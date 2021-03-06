﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keyboard : MonoBehaviour
{
    private float PlayerSpeed = 1;
    private float SpeedOffset = 0.1f;
    private float SpeedOffset0 = 0.1f;

    private float Speed;
    private GameObject[] respawns;
    private int check = 0;

    public Text PickUpText;
    public GameObject[] checkpoints;

    // Set the player speed according to the slider values from the main menu
    void Start()
    {
        if (GlobalVariables.Instance != null)
        {
            PlayerSpeed = GlobalVariables.Instance.speed / GlobalVariables.Instance.difficulty;
        }
        else {
            PlayerSpeed = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if this game object has collided with a collectible game object
        if (other.gameObject.CompareTag("PickUp") && gameObject.tag == "Player")
        {
            // deactivate the collectible
            other.gameObject.SetActive(false);
            float random = Random.Range(0.0f, 3.0f);

            // choose with action happens based on a generated random number
            // double speed
            if (random < 1)
            {
                SpeedOffset = 2f * SpeedOffset0;
                PickUpText.text = "Double Speed";
            }
            // half speed
            if (random > 2)
            {
                SpeedOffset = 0.5f * SpeedOffset0;
                PickUpText.text = "Half Speed";
            }
            // instant respawn
            if (random >= 1 && random <= 2)
            {
                SpeedOffset = SpeedOffset0;
                // itterate over all respawn points to find the closest one
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
                // respawn at the closest respawn point
                transform.position = closest.transform.position;
                transform.rotation = closest.transform.rotation;
                PickUpText.text = "Respawn";
            }

        }
        // check if this game object arrived at the finish line 
        else if (other.gameObject.CompareTag("Finish") && gameObject.CompareTag("Player"))
        {
            if (other.transform == checkpoints[check].transform)
            {
                check++;
            }
            // set the winnig variable to true
            if (check == 3)
            {
                GlobalVariables.Instance.win = true;
                SceneManager.LoadScene("End");
            }
        }

    }

    // Player movement from keyboard
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
