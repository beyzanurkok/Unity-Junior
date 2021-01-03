using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    //Scripts for maincamera to follow the player
    public GameObject plane;
    private Vector3 offset=new Vector3(28,7,13); // Position of the maincamera

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;// Camera location calculated by adding the camera's position to the player's position


    }
}
