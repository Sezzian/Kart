using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public GameObject Taxi;
    public GameObject PoliceCar;
    public GameObject TaxiKart;
    public GameObject PoliceKart;

    // Start is called before the first frame update
    void Start()
    { 
        if (!GlobalVariables.Instance.player)
        {
            Taxi.SetActive(false);
            PoliceCar.SetActive(true);
            PoliceKart.GetComponent<AudioSource>().volume = GlobalVariables.Instance.sound;
        }
        else
        {
            PoliceCar.SetActive(false);
            Taxi.SetActive(true);
            TaxiKart.GetComponent<AudioSource>().volume = GlobalVariables.Instance.sound;
        }

    }
}
