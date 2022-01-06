using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatecamera : MonoBehaviour
{
    //var
    public float rotationSpeed;

    float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        //gets player input
        horizontalInput = Input.GetAxis("Horizontal");

        //uses horizontal input to control
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

    }
}
