using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public float speed = 5.0f;
    private float powerupStrenghth = 15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndıcator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");                        
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);        // Player movement with arrow keys

        powerupIndıcator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // synchronizes the player position with the position of the powerupIndıcator

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))                                    // when player takes powerup
        {
            hasPowerup = true;
            powerupIndıcator.gameObject.SetActive(true);                    // powerupIndıcator is  activated
            Destroy(other.gameObject);                                      // powerup is destroyed
            StartCoroutine(PowerupCountdownRoutine());                     
        }
    }
    IEnumerator PowerupCountdownRoutine()                                  // Countdown method for  powerupIndıcator
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndıcator.gameObject.SetActive(false);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)   // itting the enemy with the power active
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer=(collision.gameObject.transform.position-transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrenghth, ForceMode.Impulse); //  the enemy is pushed
            Debug.Log("Player collided with " + collision.gameObject.name + "with powerup set to " + hasPowerup);
        }
    }
}
