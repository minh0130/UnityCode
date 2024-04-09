using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float speed, rotateSpeed, boost;
    Rigidbody2D rb;

    public bool hasMail;
    public Color32 hasMailColor;
    public Color32 defaultColor;
    public SpriteRenderer playerSprite;
    public AudioSource hitSomething;
    public AudioSource pickUpMail, dropOffMail;
    public AudioSource boostSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasMail = false;
        playerSprite.color = defaultColor;
        boost = 1;
    }

    void FixedUpdate() // control the car
    {
        if ( Input.GetAxis("Vertical") != 0 )
        {
            rb.velocity = Input.GetAxis("Vertical") * transform.up * speed * boost;
        }
        else{
            rb.velocity = Vector2.zero;
        }

        if ( Input.GetAxis("Horizontal") != 0 )
        {
            rb.angularVelocity = -Input.GetAxis("Horizontal") * rotateSpeed;
        }
        else{
            rb.angularVelocity = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other) // correct mails
    {
        if ( other.tag == "Mail" && hasMail == false )
        {
            pickUpMail.Play();
            playerSprite.color = hasMailColor;
            hasMail = true;
            Destroy(other.gameObject, 0.5f); // destroy the mail after 0.5 seconds
            gameManager.UpdateMail();
        }

        if ( other.tag == "Mailbox" && hasMail == true ) // put mail in the mailbox
        {
            dropOffMail.Play();
            playerSprite.color = defaultColor;
            hasMail = false;
            gameManager.UpdateDeliveries();
        }

        if ( other.tag == "Boost" ) // boost the car
        {
            boostSound.Play();
            boost = 1.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        hitSomething.Play();
        gameManager.UpdateHit();
        boost = 1;
    }
}