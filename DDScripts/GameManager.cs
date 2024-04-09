using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text mailLeftText, timeText, deliveriesText, winText, adviceText;
    public int mailLeft, deliveriesMade, hit;
    public SpriteRenderer winBackground;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        hit = 0;
        winBackground.enabled = false;
        mailLeftText.text = "Mail Left: " + mailLeft;
        deliveriesText.text = "Deliveries: " + deliveriesMade;

    }

    // Update is called once per frame
    void Update()
    {
        if ( deliveriesMade == 10 ) // show when the game finish
        {
            winBackground.enabled = true;
            winText.text = "Well done!\nYou've delivered all the mail in \n" 
            + (Mathf.Round(timer * 10) / 10) + " seconds!"
            + "\nYou hit the object for " + hit + " times!" ;
            if ( hit < 20 )
            {
                adviceText.text = "Your driving skill is very well!";
            }
            else
            {
                adviceText.text = "Hmm..., you should drive more carefuly\nPractice more!";
            }
        } 
        else
        {
            timer += Time.deltaTime; // Time.delta represents the amount of time between the last frame and the current frame
            timeText.text = "Timer: " + Mathf.Round(timer * 10) /10;
        }
    }

    public void UpdateMail() // update the number of mail you left
    {
        mailLeft--;
        mailLeftText.text = "Mail Left: " + mailLeft;
    }

    public void UpdateDeliveries() // update the number of mail you correct
    {
        deliveriesMade++;
        deliveriesText.text = "Deliveries: " + deliveriesMade;
    }

    public void UpdateHit() // update your hit time
    {
        if ( deliveriesMade < 10 )
        {
            hit++;
        }
    }
}
