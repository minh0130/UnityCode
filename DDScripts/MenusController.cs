using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // required to change scenes

public class MenusController : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            SceneManager.LoadScene("GameScreen"); // reload the GameScreen scene
        }
    }
    
    public void Game()
    {
        SceneManager.LoadScene("GameScreen"); // load the GameScreen scene
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions"); // load the Instruction scene
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu"); // load the MainMenu scene
    }

    public void QuitGame()
    {
        Application.Quit(); // quit the game
    }
}
