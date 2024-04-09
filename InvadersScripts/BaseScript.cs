using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    float opacity; // represents opacity of the base
    public SpriteRenderer baseSprite; // the spriterenderer, required to change opacity

    // Start is called before the first frame update
    void Start()
    {
        opacity = 1; // start with full opacity
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "InvaderBullet" ) // when a bullet enters base
        {
            opacity = opacity - 0.05f; // update the opacity value
            baseSprite.color = new Color( 255, 255, 255, opacity ); // assign the new opacity to the base
            Destroy(other.gameObject); // destroy the bullet
            
            if ( opacity < 0 ) // check if opacity is less than 0
            {
                Destroy(this.gameObject); // destroy the base
            }
        }
    }
}
