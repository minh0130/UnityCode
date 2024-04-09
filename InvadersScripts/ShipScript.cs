using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed, delayTime;
    public GameObject bullet;
    public SpriteRenderer shipSprite;
    public Color normalColor;
    Rigidbody2D rb;
    GameManager gameManager;
    SoundController soundController;
    float timeSinceLastFire;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false; // put the active to false
        rb = GetComponent<Rigidbody2D>(); // active collider
        Invoke("EnableCollider", 2.0f); // Runs the EnableCollider method after some amount of time
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // find the GameManager
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>(); // find the SoundController
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2( Input.GetAxisRaw("Horizontal") * speed , 0 ); // player movement
    }

    void Update()
    {
        timeSinceLastFire += Time.deltaTime; // count time

        if ( Input.GetKey(KeyCode.Space) && timeSinceLastFire > delayTime ) // check if SPACE pressed and enough time has passed
        {
            Instantiate( bullet, transform.position, transform.rotation ); // instantiate bullet with ship’s position and rotation
            timeSinceLastFire = 0; // reset time to 0
            soundController.ShipShoot(); // play the shooting sound
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "InvaderBullet" &&  active == true ) // when an object enters this object
        {
            gameManager.UpdateLives(); // update lives
            soundController.HitShip(); // play the hitting sound
            Destroy(other.gameObject); // destroy the bullet
            Destroy(this.gameObject); // destroy the ship
        }
    }

    void EnableCollider()
    {
        active = true; // put active to true
        shipSprite.color = normalColor; // change the ship color
    }
}
