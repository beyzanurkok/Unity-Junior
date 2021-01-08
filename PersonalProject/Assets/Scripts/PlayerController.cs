using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float ztopBoundary=19.0f;
    private float zbottomBoundary = 2.6f;
    private float speed = 10.0f;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    //Moves the player based on arrow key input

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Prevent the player from leaving top or bottom of the screen

    void ConstrainPlayerPosition()
    {
        if (transform.position.z > ztopBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ztopBoundary);
        }
        if (transform.position.z < zbottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbottomBoundary);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with enemy");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
;
        }
    }
}
