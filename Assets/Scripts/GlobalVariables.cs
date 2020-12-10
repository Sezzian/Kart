using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to transfer global variables from one scene to another
public class GlobalVariables : MonoBehaviour
{
    // police car == false, taxi == true
    public bool player = false;

    // slider values from main menu 
    public float speed = 1f;
    public float sound = 1f;
    public float difficulty = 1f;

    // To select the appropriate message in the end screen
    public bool win = false;

    public static GlobalVariables Instance;

    // Check if an instance has been build already, if not create one 
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
