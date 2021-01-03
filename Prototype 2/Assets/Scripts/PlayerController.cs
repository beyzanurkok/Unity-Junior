using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public GameObject ProjectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //prevents player from leaving scene

        if (transform.position.x  <-xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Player movement horizontally with arrow keys
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*HorizontalInput*Time.deltaTime*speed);


        // Throws pizza when pressing space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate method used to create an already existing object
            Instantiate(ProjectilePrefab, transform.position, ProjectilePrefab.transform.rotation); 
        }
    }
}
