using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    float forwardInput;
    float sideInput;
    private float PowerUpStrangth = 15;

    public GameObject powerUpInd;


    // for refrences
    private GameObject focalPoint;
    public GameObject endscreen;
    Rigidbody rb;


    public bool hasPowerUp = false;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("CameraPivot");
    }

    // Update is called once per frame
    void Update()
    {
        // to call user input
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

 

        // indicator follows player
        powerUpInd.transform.position = transform.position;

        //end play
        if (transform.position.y <= -10)
        {
            endscreen.SetActive(true);
            Time.timeScale = 0;

        }
        


    }


    private void FixedUpdate()
    {

        //
        rb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed);
        rb.AddForce(focalPoint.transform.right * sideInput * playerSpeed);


    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "powerup")
        {

            hasPowerUp = true;


            // indecates power up
            powerUpInd.gameObject.SetActive(true);

            //delets power up on picking it up
            Destroy(other.gameObject);

            StartCoroutine(PowerUpCountDown());

            
        }


    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(5);
        // indecates power up
        powerUpInd.gameObject.SetActive(false);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            // add power to the player
            enemyRb.AddForce(awayFromPlayer * PowerUpStrangth, ForceMode.Impulse);

            
        }
    }
}
