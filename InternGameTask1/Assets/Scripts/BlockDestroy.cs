using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void Update()
    {

        if (transform.position.y <GameObject.Find("Ball").transform.position.y-5 )
        {
            Destroy(gameObject);
            gameManager.Spawn();

        }
    }
}
