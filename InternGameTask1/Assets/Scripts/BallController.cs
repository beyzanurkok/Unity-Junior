using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Color[] colors;
    [SerializeField] float bouncingForce = 10;
    Rigidbody2D ballRb;
    GameManager gameManager;
    int index;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ballRb = GetComponent<Rigidbody2D>();
        RandomColor();
    }

    void Update()
    {
        //The ball bounces when the left mouse button is clicked. 
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameManager.isGameActive )
        {
            Vector2 velocity = ballRb.velocity;
            velocity.y = bouncingForce;
            ballRb.velocity = velocity;
        }

    }
    public void RandomColor()
    {
        index = Random.Range(0, 4);
        gameObject.GetComponent<SpriteRenderer>().color = colors[index];
    }

}