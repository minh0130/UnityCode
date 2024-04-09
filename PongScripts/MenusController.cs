using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
    }

    public void SoloMode()
    {
        SceneManager.LoadScene("SoloMode"); // load the SoloMode scene
    }

    public void TwoPlayer()
    {
        SceneManager.LoadScene("2PlayerMode"); // load the 2PlayerMode scene
    }

    public void VSCP()
    {
        SceneManager.LoadScene("VSCP"); // load the VSCP scene
    }

    public void OwnMode()
    {
        SceneManager.LoadScene("OwnMode"); // load the OwnMode scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // load the MainMenu scene
    }

    public void QuitGame()
    {
        Application.Quit(); // quit the game
    }
    
}
