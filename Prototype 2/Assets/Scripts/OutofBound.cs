using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBound : MonoBehaviour
{

    private float topBound = 30.0f;
    private float bottomBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Game objects are destroyed when they leave the scene
        if (transform.position.z>topBound || transform.position.z < bottomBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
       
    }
}
