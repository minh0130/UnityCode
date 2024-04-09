using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    public Text titleText, secondaryText;
    public float fadeTime, scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // unpause the game
        titleText.canvasRenderer.SetAlpha(0); // set the title to be fully transparent
        secondaryText.canvasRenderer.SetAlpha(0); // set secondary text to be transparent
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector3.up * scrollSpeed * Time.deltaTime ); // move up 
        
        if ( transform.position.y > 8 ) // when scrolling text fades out the screen
        {
            titleText.CrossFadeAlpha( 1.0f, fadeTime, true ); // appear Title Text
            secondaryText.CrossFadeAlpha( 1.0f, fadeTime, true ); // appear Secondary Text

            if ( Input.GetKey(KeyCode.Return) ) // when Return key is paused
            {
                if ( SceneManager.GetActiveScene().name == "WinEnd" || SceneManager.GetActiveScene().name == "LoseEnd" )
                {
                    SceneManager.LoadScene("Menus"); // load the Menus scene
                }
                if ( SceneManager.GetActiveScene().name == "Menus" )
                {
                    SceneManager.LoadScene("Level1"); // load the Level1 scene
                }
            }
        }
    }
}
