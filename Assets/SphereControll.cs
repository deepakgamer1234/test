using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControll : MonoBehaviour
{
    public float rotationSpeed = 1f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, rotationSpeed),Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) { this.transform.Rotate(new Vector3(0, 0, -rotationSpeed), Space.World); }
      /*  else if (Input.GetKey(KeyCode.UpArrow)) { this.transform.Rotate(new Vector3( -rotationSpeed,0, 0),Space.World); }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            this.transform.Rotate(new Vector3( rotationSpeed,0, 0), Space.World);
        }*/
    }
}
