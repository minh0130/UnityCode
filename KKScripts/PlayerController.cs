using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedMultiplier;
    public Vector2 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPosition; // go to the start position
    }

    void FixedUpdate() // use FixedUpdate anytime you are modifying the Rigidbody
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if ( Input.GetAxisRaw("Horizontal") != 0 ) //left or right arrows
            {
                rb.velocity = new Vector2( Input.GetAxisRaw("Horizontal") * speedMultiplier , rb.velocity.y ); //assign a x-velocity, maintain y velocity
            }
            else if (Input.GetAxisRaw("Vertical") != 0 ) // up or down arrows
            {
                rb.velocity = new Vector2( rb.velocity.x, Input.GetAxisRaw("Vertical") * speedMultiplier ); // assign a y-velocity, maintain x velocity
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0); // assign 0 velocity
        }
    }

    // check for when 2 Colliders hit each other
    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.tag == "Wall" )
        {
            transform.position = startPosition;
        }
    }

    //check for when 2 Colliders enter/overlap each other
    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Wall" )
        {
            transform.position = startPosition; // go back to the start position
        }

        if ( other.gameObject.tag == "End1" )
        {
            SceneManager.LoadScene( "Level2" ); // go to Level 2
        }

        if ( other.gameObject.tag == "End2" )
        {
            SceneManager.LoadScene( "Level3" ); // go to Level 3
        }

        if ( other.gameObject.tag == "End3" )
        {
            SceneManager.LoadScene( "winTextpage" ); // go to winTextpage
        }
    }
}
