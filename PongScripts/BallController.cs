using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float xSpeed, ySpeed, yPos, speedMultiplier; // assign the value larger than 1
    public int xDirection, yDirection, num;
    public GameManager gameManager; // create a reference to the GameManager
    public SoundController soundController; // create a reference to the SoundController

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall(); // reset the location of ball 
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            rb.velocity = rb.velocity * speedMultiplier; // update the speed
            soundController.HitPaddleSound(); // play sound for ball hitting paddle// play sound for ballhitting paddle
        }

        if (other.gameObject.tag == "Wall")
        {
            soundController.HitWallSound();// play sound for ball hitting wall
        }

        if (other.gameObject.tag == "SoloPaddle")
        {
            gameManager.UpdateSoloScore(); // call method to update solo mode score
            rb.velocity = rb.velocity * speedMultiplier; // update the speed
            soundController.HitWallSound(); // play sound for ball hitting paddle
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Reset1") 
        {
            ResetBall(); // call ResetBall() method
            gameManager.UpdateP2Score(); // call UpdateP2Score method via gameManager
        }

        if (other.gameObject.tag == "Reset2")
        {
            ResetBall(); // call ResetBall() method
            gameManager.UpdateP1Score(); // call UpdateP1Score method via gameManager
        }
        if (other.gameObject.tag == "Reset3")
        {
            ResetBall(); // call ResetBall() method
            gameManager.UpdateCPScore(); // call UpdateP1Score method via gameManager
        }
        

        if (other.gameObject.tag == "GameOver")
        {
            gameManager.SoloGameOver(); // call SoloGameOver method via gameManager
        }
    }

    public void ResetBall() // a method that puts the ball at a random y-position, and choses a random direction
    {
        yPos = Random.Range(-2.5f, 2.5f); // generate random y position from -2.5 to 2.5
        transform.position = new Vector2(0, yPos); // go to the y position
        
        num = Random.Range(1, 5); // generate random number between 1 and 4

        if ( num == 1 )
        {
            rb.velocity = new Vector2( xSpeed, ySpeed );
        }
        else if ( num == 2 )
        {
            rb.velocity = new Vector2( xSpeed, -ySpeed );
        }
        else if ( num == 3 )
        {
            rb.velocity = new Vector2( -xSpeed, ySpeed );
        }
        else if ( num == 4 )
        {
            rb.velocity = new Vector2( -xSpeed, -ySpeed );
        }
    }
}
