using System.Collections;
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
            // check if a player has been selcted (for development purposes only)
            if (!GlobalVariables.Instance.player)
            {
                // Activate or deactivate the camera of the selected Kart
                PoliceCam.SetActive(true);
                TaxiCam.SetActive(false);
                // Tag the selected Kart
                PoliceKart.tag = "Player";
                TaxiKart.tag = "AI";

                // Enable or disable the keyboard script
                PoliceKart.GetComponent<Keyboard>().enabled = true;
                TaxiKart.GetComponent<Keyboard>().enabled = false;

                // Enable or disable the NavMeshAgent and the NavMesh control script for the not selected Kart
                PoliceKart.GetComponent<NavMeshAgent>().enabled = false;
                PoliceKart.GetComponent<NpcControl>().enabled = false;
                TaxiKart.GetComponent<NavMeshAgent>().enabled = true;
                TaxiKart.GetComponent<NpcControl>().enabled = true;

            }
            // do the same as for the above if loop, if no Kart has been selected (for developement purposes only)
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
            // change the sound volume according to the slider value
            PoliceKart.GetComponent<AudioSource>().volume = PoliceKart.GetComponent<AudioSource>().volume * GlobalVariables.Instance.sound;
            TaxiKart.GetComponent<AudioSource>().volume = TaxiKart.GetComponent<AudioSource>().volume * GlobalVariables.Instance.sound;

        }
    }
}
