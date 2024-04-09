using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    Rigidbody2D rb; // the rigidbody, required to update velocity
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // find this object’s rigidbody
        rb.velocity = new Vector2( 0, speed ); // assign a velocity in the y-direction
    }
}
