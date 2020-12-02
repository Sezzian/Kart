﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Startup : MonoBehaviour
{
    public GameObject Taxi;
    public GameObject PoliceCar;
    public GameObject TaxiKart;
    public GameObject PoliceKart;
    public GameObject PoliceCam;
    public GameObject TaxiCam;

    // Start is called before the first frame update
    void Start()
    {
        //if (GlobalVariables.Instance != null)
        {
            if (!GlobalVariables.Instance.player)
            {
                PoliceCam.SetActive(true);
                TaxiCam.SetActive(false);
                PoliceKart.tag = "Player";
                TaxiKart.tag = "AI";

                PoliceKart.GetComponent<Keyboard>().enabled = true;
                TaxiKart.GetComponent<Keyboard>().enabled = false;

                PoliceKart.GetComponent<NavMeshAgent>().enabled = false;
                PoliceKart.GetComponent<NpcControl>().enabled = false;
                TaxiKart.GetComponent<NavMeshAgent>().enabled = true;
                TaxiKart.GetComponent<NpcControl>().enabled = true;

            }
            else
            {
                PoliceCam.SetActive(false);
                TaxiCam.SetActive(true);
                TaxiKart.tag = "Player";
                PoliceKart.tag = "AI";

                PoliceKart.GetComponent<Keyboard>().enabled = false;
                TaxiKart.GetComponent<Keyboard>().enabled = true;

                PoliceKart.GetComponent<NavMeshAgent>().enabled = true;
                PoliceKart.GetComponent<NpcControl>().enabled = true;
                TaxiKart.GetComponent<NavMeshAgent>().enabled = false;
                TaxiKart.GetComponent<NpcControl>().enabled = false;
            }

            PoliceKart.GetComponent<AudioSource>().volume = PoliceKart.GetComponent<AudioSource>().volume * GlobalVariables.Instance.sound;
            TaxiKart.GetComponent<AudioSource>().volume = TaxiKart.GetComponent<AudioSource>().volume * GlobalVariables.Instance.sound;

        }
    }
}
