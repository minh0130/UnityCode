using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource hitPaddle;
    public AudioSource hitWall;
    public AudioSource scorePoint;
    public AudioSource victorySound;
    public AudioSource lostSound;

    public void StopMusic()
    {
        backgroundMusic.Stop(); // stop the BGM
    }

    public void HitPaddleSound()
    {
        hitPaddle.Play(); // play when the ball hits paddle
    }

    public void VictorySound()
    {
        victorySound.Play(); // play when player wins
    }

    public void HitWallSound()
    {
        hitWall.Play(); // play when the ball hits walls
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
