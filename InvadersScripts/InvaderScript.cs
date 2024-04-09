using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour // attach to Invader prefab object
{
    Rigidbody2D rb;
    GameManager gameManager;
    SoundController soundController;
    public GameObject invaderParent, invaderBullet;
    public float speed, speedMultiplier;
    public int dice;

    // Start is called before the first frame update
    void Start()
    {
        dice = 0; // reset the dice to 0
        rb = GetComponent<Rigidbody2D>(); // find this object’s rigidbody
        rb.velocity = new Vector2(speed, 0); // assign a starting velocity in the x-direction
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // find the GameManager
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>(); // find the SoundController
    }

    // Update is called once per frame
    void Update()
    {
        dice = Random.Range(1, 2001); // roll the dice
        if ( dice == 1 && Time.timeScale == 1 ) // if 1 is rolled
        {
            Instantiate(invaderBullet, transform.position, transform.rotation); // instantiate a bullet
            dice = 1; // reset the dice to 1
            soundController.InvaderShoot(); // play the shooting sound of invader
        }
        
        speed = speed + Time.deltaTime * speedMultiplier; // increase speed over time
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "LeftWall" )
        {
            invaderParent.BroadcastMessage("MoveRight"); // broadcast a  message to move right
        }

        if ( other.gameObject.tag == "RightWall" )
        {
            invaderParent.BroadcastMessage("MoveLeft"); // broadcast a  message to move left
        }

        if ( other.gameObject.tag == "PlayerBullet" ) // if it's a player bullet
        {
            gameManager.UpdateScore(); // update the score
            soundController.ScoreSound(); // play the score sound
            Destroy(other.gameObject); // destroy the bullet
            Destroy(this.gameObject); // destroy the invader
        }

        if ( other.gameObject.tag == "GameOver" )
        {
            gameManager.GameOver(); // runs the GameOver method
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2( speed, 0 ); // assign a new velocity to the right
        transform.position = transform.position - transform.up * 0.05f; // move the invader down some amount
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2( -speed, 0 ); // assign a new velocity to the left
        transform.position = transform.position - transform.up * 0.05f; // move the invader down some amount
    }
}
