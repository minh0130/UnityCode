using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticalScript : MonoBehaviour
{
    public float speedY;
    public float yMax, yMin;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( rb.velocity.x, speedY ); // set the velocity of paddles
    }

    void FixedUpdate()
    {
        if ( transform.position.y > yMax || transform.position.y < yMin ) // set range that paddle can move
        {
            speedY = -speedY;
            rb.velocity = new Vector2( rb.velocity.x,speedY );
        }

    }

}
