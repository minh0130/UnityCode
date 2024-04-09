using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddleScript : MonoBehaviour
{
    public Rigidbody2D computerRB;
    public Rigidbody2D ballRB;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if ( computerRB.transform.position.y < ballRB.transform.position.y ) // set the direction of paddle
        {
            computerRB.velocity = new Vector2( 0, speed ); // move up
        }
        else
        {
            computerRB.velocity = new Vector2( 0, -speed ); // move down
        }
    }
}
