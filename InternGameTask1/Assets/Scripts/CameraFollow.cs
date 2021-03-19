using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        float BallPos = target.position.y + 2.2f;
        if (BallPos > transform.position.y )
        {
            transform.position = new Vector3(transform.position.x , BallPos, transform.position.z);
        }  
    }
}
