using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private float deleteE = -15;
    private Vector3 lookDirection;

    //calls
    Rigidbody enemyRb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce( lookDirection* speed);

        if (transform.position.y <= deleteE)
        {
            Destroy(gameObject);
        }
    }
}
