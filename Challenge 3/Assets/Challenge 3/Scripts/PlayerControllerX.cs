using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private float topBoundary = 15;
    private float bottomBoundary = 1;
    private float boundaryForce = 2;
    public float floatForce;
    private float gravityModifier = 1.0f;
    
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boundarySound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = gameObject.GetComponent<Rigidbody>();


        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y < bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            playerRb.AddForce(Vector3.up * boundaryForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(moneySound, 1.0f);


        }

        if (gameObject.transform.position.y > topBoundary)
        {
            transform.position = new Vector3(transform.position.x, 15, transform.position.z);
            playerRb.AddForce(Vector3.up * -boundaryForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(moneySound, 1.0f);
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y<topBoundary)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Invoke("DestroyBalloon", 1);


        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            


        }



    }
    private void DestroyBalloon()
    {
        Destroy(gameObject);
    }

}
