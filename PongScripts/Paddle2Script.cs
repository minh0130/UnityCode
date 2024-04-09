using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2Script : MonoBehaviour
{
    public float paddleSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2( 0, Input.GetAxisRaw("Vertical2") ) * paddleSpeed; // controll Paddle2
    }
}