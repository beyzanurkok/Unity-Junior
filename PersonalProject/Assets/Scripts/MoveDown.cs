using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody EnemyRb;
    private float zDestroy = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z<-zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
