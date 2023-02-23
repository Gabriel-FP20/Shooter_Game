using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static float timeRemaining;    
    public TMP_Text timeText;
    public TMP_Text pointText;
    public TMP_Text scoreText;
    public bool timerIsRunning;


    public static int score;

    public PanelController victory;

    void Start()
    {   
        score = 0;
        Time.timeScale = 1;
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {   
        pointText.text = score.ToString();
        scoreText.text = score.ToString(); 
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        if(timerIsRunning == false)
        {
            victory.VictoryPanel();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
