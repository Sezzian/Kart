using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    // Rotate collectable objects to look more fance
    void Update()
    {
        transform.Rotate(Vector3.up * 45 * Time.deltaTime, Space.World);
    }
}
