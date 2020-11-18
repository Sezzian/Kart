using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    public GameObject WinText;
    public GameObject LoseText;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariables.Instance.win)
        {
            WinText.SetActive(true);
            LoseText.SetActive(false);
        }
        else {
            WinText.SetActive(false);
            LoseText.SetActive(true);
        }

      
    }
}
