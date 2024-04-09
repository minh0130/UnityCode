using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        transform.position = new Vector3( player.transform.position.x, player.transform.position.y, -10 );
        // follow the player's x and y position, but use -10 for the z-value
    }
}
