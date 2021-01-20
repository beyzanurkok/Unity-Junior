﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - enemyRb.transform.position).normalized; // determines the enemy's direction
        enemyRb.AddForce(lookDirection * speed);                                                    

        if (transform.position.y < -10)                                                              // enemies falling from the platform are destroyed
        {
            Destroy(gameObject);
        }
        
    }
}
