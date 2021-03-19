using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBound : MonoBehaviour
{

    Collider2D ControlBoundCollider;
    BallController ballController;
    private GameManager gameManager;

    //Collider is destroyed after the ball has passed.
    private void Start()
    {
        ControlBoundCollider = GetComponent<Collider2D>();
        ControlBoundCollider.isTrigger = true;
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {//when the ball comes out of the block  changes the bouncing ball’s color ,score increases and  the block of trigger is false.
        ballController.RandomColor();
        gameManager.UpdateScore(5);
        ControlBoundCollider.isTrigger = false;
    }






}