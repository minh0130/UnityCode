using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //required to change scenes

public class ButtonController : MonoBehaviour
{   
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu"); // load the MainMenu scene
    }
    
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction"); // load the MainMenu scene
    }


    public void Level1()
    {
        SceneManager.LoadScene("Level1"); // load the Level1 scene
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2"); // load the Level2 scene
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3"); // load the Level3 scene
    }
}
