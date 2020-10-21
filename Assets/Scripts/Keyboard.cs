using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public int PlayerSpeed = 1;
    private float SpeedOffset = 0.1f;

    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
      
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

        transform.Translate(velocity);
        transform.Rotate(rotation);
    }
}
