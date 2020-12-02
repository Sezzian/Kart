using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // police car == false, taxi == true
    public bool player = false;
    public float speed = 1f;
    public float sound = 1f;
    public float difficulty = 1f;
    public bool win = false;

    public static GlobalVariables Instance;

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
