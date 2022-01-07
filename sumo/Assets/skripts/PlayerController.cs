using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    float forwardInput;
    float sideInput;


    // for refrences
    private GameObject focalPoint;
    Rigidbody rb;


    private bool hasPowerUp;

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
        sideInput = Input.GetAxis("Horizontal");

        //
        rb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed);
        rb.AddForce(focalPoint.transform.right * sideInput * playerSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "powerup")
        {

            hasPowerUp = true;

            //delets power up on picking it up
            Destroy(other.gameObject);
        }


    }
}
