using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D other) // when an object enters this object
    {
        Destroy(other.gameObject); // destroys the game object that enters this object
    }
}
