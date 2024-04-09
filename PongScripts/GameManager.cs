using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallController ballController; // create a reference to the BallController
    public SoundController soundController; // create a reference to the SoundController
    public Text p1Text, p2Text, cpText, centerText;
    public int p1Score, p2Score, soloScore, cpScore;
    public GameObject ball;
    public GameObject playAgain, mainMenu;
    public bool gameOver; // boolean representing if the game is over
    
    // Start is called before the first frame update 
    void Start()
    {
        Time.timeScale = 1; // start the game
        // turn off the buttons
        playAgain.SetActive(false);
        mainMenu.SetActive(false);
        gameOver = false; // turn off the gameOver
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameOver == false ) 
        {
            if (p1Score >= 3 || p2Score >= 3 || soloScore >= 10 || cpScore >=3)
            {
                if ( p1Score >= 3 )
                    centerText.text = "Player 1 WINS!";
                else if ( p2Score >= 3 )
                    centerText.text = "Player 2 WINS!";
                else if ( soloScore >= 10 )
                    centerText.text = "You WIN!";
                else if( cpScore >=3 )
                    centerText.text = "Computer WINS!";
                
                gameOver = true; // turn on the gameOver
                Time.timeScale = 0; // pause the game
                soundController.VictorySound(); // play victory music
                soundController.StopMusic(); // stop background music
                // Active both menu overlay game object buttons
                playAgain.SetActive(true);
                mainMenu.SetActive(true);
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu"); // go back to MainMenu scene when you push escape key
        }
    }

    public void UpdateSoloScore()
    {
        soloScore++; // add score in Solo mode
        p1Text.text = soloScore.ToString(); // change the score
        soundController.ScoreSound(); // play scoreSound
    }

    public void UpdateP1Score()
    {
        p1Score++; // add score to P1
        p1Text.text = p1Score.ToString(); // change the score
        soundController.ScoreSound(); // play scoreSound
    }

    public void UpdateP2Score()
    {
        p2Score++; // add score to P2
        p2Text.text = p2Score.ToString(); // change the score
        soundController.ScoreSound(); // play scoreSound
    }
    public void UpdateCPScore()
    {
        cpScore++; // add score to Computer
        cpText.text = cpScore.ToString(); // change the score
        soundController.ScoreSound(); // play scoreSound
    }

    public void SoloGameOver()
    {
        // Active both menu overlay game object buttons
        playAgain.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0; // pause the game
        soundController.StopMusic(); // stop the game music
        centerText.text = "You lose!"; // update the center text
        soundController.LostSound(); // play the lose sound
    }
}
