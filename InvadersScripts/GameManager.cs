using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject invaderParent, ship, shipSpawn;
    public Text centerText, livesText, scoreText;
    public int score, lives;
    public SpriteRenderer textBackground;
    SoundController soundController;
    bool playOnce;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // unpause the game
        Instantiate(ship, shipSpawn.transform.position, shipSpawn.transform.rotation); // spawn the ship
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>(); // find the SoundControlleer
        lives = 3; // set lives to 3
        score = 0; // set score to 0
        livesText.text = "Lives: " + lives; // show the left lives in the screen
        scoreText.text = score + " / 4200"; // show the score in the screen
        playOnce = true; // put playOnce to true
        textBackground.enabled = false; // turn off the Text Background
        }

    // Update is called once per frame
    void Update()
    {
        if ( score >= 4200 )
        {            
            Time.timeScale = 0; // pause the game

            if ( SceneManager.GetActiveScene().name == "Level1" ) // if player is in the Level1 scene
            {
                centerText.text = "You win!\nPress RETURN to go to the next level."; // show winning message
                soundController.StopMusic(); // stop the BGM
                textBackground.enabled = true; // turn on Text Background
                
                if ( playOnce == true )
                {
                    soundController.VictorySound(); // play the Victory sound
                    playOnce = false; // put playOnce to false
                }
                

                if ( Input.GetKey(KeyCode.Return) )
                {
                    SceneManager.LoadScene("Level2"); // load the Level2 scene
                    playOnce = true; // put playOnce to true
                }
            }

            if ( SceneManager.GetActiveScene().name == "Level2" ) // if player is in the Level2 scene
            {
                centerText.text = "You win!\nPress RETURN to go to the ending"; // show winning message
                soundController.StopMusic(); // stop the BGM
                textBackground.enabled = true; // turn on Text Background

                if ( playOnce == true )
                {
                    soundController.VictorySound(); // play the Victory sound
                    playOnce = false; // put playOnce to false
                }

                if ( Input.GetKey(KeyCode.Return) )
                {
                    SceneManager.LoadScene("WinEnd"); // load the WinEnd scene
                }
            }
        }

        if ( lives <= 0 )
        {
            Time.timeScale = 0; // pause the game
            soundController.StopMusic(); // stop the BGM
            textBackground.enabled = true; // turn on the Text Background

            if ( playOnce == true )
                {
                    centerText.text = "Lost all lives.\nPress RETURN to go to the next scene."; // show losing message
                    soundController.LostSound(); // play the Lost sound
                    playOnce = false; // put playOnce to false
                }

            if ( Input.GetKey(KeyCode.Return) )
                {
                    SceneManager.LoadScene("LoseEnd"); // load the LoseEnd scene
                }
        }
    }

    public void UpdateScore()
    {
        score += 100; // add 100 score 
        scoreText.text = score.ToString() + " / 4200"; // update the new score
    }

    public void UpdateLives()
    {
        lives -= 1; // subtract 1 live
        livesText.text = "Lives: " + lives; // update the new lives

        if ( lives > 0 )
        {
            Instantiate( ship, shipSpawn.transform.position, shipSpawn.transform.rotation ); // spawn a new ship
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0; // pause the game
        lives = 0; // set lives to 0
        soundController.StopMusic(); // stop the BGM
        playOnce = false;

        if ( playOnce == false )
        {
            centerText.text = "Invaders reached bottom. You lose.\nPress RETURN to go to the next scene."; // show losing message
            soundController.LostSound(); // play the Lost sound
        }

        if ( Input.GetKey(KeyCode.Return) )
        {
            SceneManager.LoadScene("LoseEnd"); // load the LoseEnd scene
        }
    }
}
