using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject kart;

    private Vector3 SpaceOffset;
    private Vector3 RotationOffset;
    private Quaternion rotation;
  
    // Start is called before the first frame update
    void Start()
    {
        SpaceOffset = transform.position - kart.transform.position;
        RotationOffset = transform.eulerAngles - kart.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Quaternion.Euler(0.0f,kart.transform.eulerAngles.y, 0.0f);
        transform.position = kart.transform.position + rotation * SpaceOffset;
        transform.eulerAngles = kart.transform.eulerAngles + RotationOffset;
    }
}
