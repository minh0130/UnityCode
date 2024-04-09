using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource hitShip;
    public AudioSource scorePoint;
    public AudioSource victorySound;
    public AudioSource lostSound;
    public AudioSource shipShoot;
    public AudioSource invaderShoot;

    public void StopMusic()
    {
        BGM.Stop(); // stop the BGM
    }

    public void VictorySound()
    {
        victorySound.Play(); // play when player wins
    }

    public void HitShip()
    {
        hitShip.Play(); // play when the bullet hits ship
    }

    public void ShipShoot()
    {
        shipShoot.Play(); // play when the ship shoot the bullet
    }

    public void InvaderShoot()
    {
        invaderShoot.Play(); // play when the invaders shoot the bullet
    }

    public void ScoreSound()
    {
        scorePoint.Play(); // play when player gets point
    }

    public void LostSound()
    {
        lostSound.Play(); // play when player lose
    }

}
