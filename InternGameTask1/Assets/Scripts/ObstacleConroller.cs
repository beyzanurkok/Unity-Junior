using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleConroller : MonoBehaviour
{
    Color obstacleColor;
    public Collider2D obstacleCollider;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        obstacleColor = gameObject.GetComponent<SpriteRenderer>().color;
        obstacleCollider = GetComponent<Collider2D>();
        obstacleCollider.isTrigger = false;
    }



    
    private void OnTriggerEnter2D(Collider2D other)
    {//If bouncing ball collides with same color, the ball will pass through the obstacle, else game over.
        if (obstacleColor.Equals(GameObject.Find("Ball").GetComponent<SpriteRenderer>().color))
        {
            obstacleCollider.isTrigger = true;
        }
        else if (!obstacleColor.Equals(GameObject.Find("Ball").GetComponent<SpriteRenderer>().color))
        {
            if (!(transform.position.y < GameObject.Find("Ball").GetComponent<BallController>().transform.position.y))
            {
                gameManager.GameOver();
            }
        }
    }
    

}