using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Configs : MonoBehaviour
{

    public TMP_Text timeText;
    public TMP_Text delayText;

    public float timeRemaining;
    public float timeToDelay;    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeRemaining);
        DisplayDelay(timeToDelay);

    }


    public void IncreaseTimer()
    {
        timeRemaining += 10;
        if(timeRemaining >= 180)
        {
            timeRemaining = 180;
        }
    }

    public void DecreaseTimer()
    {
        timeRemaining -= 10;
        if(timeRemaining <= 60)
        {
            timeRemaining = 60;
        }
    }

    public void IncreaseDelay()
    {
        timeToDelay ++;

    }

    public void DecreaseDelay()
    {
        timeToDelay = timeToDelay - 1;
        if(timeToDelay <= 1)
        {
            timeToDelay = 1;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayDelay(float timeToDelay)
    {
        delayText.text = timeToDelay.ToString() + " seg";
    }

    public void Play()
    {
        GameController.timeRemaining = timeRemaining;
        SpwanEnemies.spwanDelay = timeToDelay;
    }
}
