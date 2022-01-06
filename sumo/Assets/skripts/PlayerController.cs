using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    float forwardInput;


    // for refrences
    private GameObject focalPoint;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("CameraPivot");
    }

    // Update is called once per frame
    void Update()
    {
        // to call user input
        forwardInput = Input.GetAxis("Vertical");


        //
        rb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed);
    }
}
