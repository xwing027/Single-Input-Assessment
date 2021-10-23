using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{
    #region Variables
    BPMManager bpmManager;

    public float tickTimer = 1.25f;
    float timerWindow = 1.25f; //sets the window for when to press, currently same window regardless of bpm

    bool hit;

    public Text timeDelay;
    public Text abilityDisplay;
    public Text stepDisplay;
    public Text scoreDisplay;
    public Text uiSecCount;

    public float failCounter;
    float stepCounter;
    public float score;

    public float time = 3.0f; //this counts the delay before gameplay starts
    #endregion

    private void Start()
    {
        bpmManager = GetComponent<BPMManager>();

        bpmManager.BPS = bpmManager.curBPM / 60;
        tickTimer = -bpmManager.BPS / 2;
        if (bpmManager.isOneTwenty)
        {
            bpmManager.OneTwentyBeat();
        }
        else
        {
            bpmManager.HundredBeat();
        }
 //set bpm to 100
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;

        if (time >= 0)
        {
            time -= Time.deltaTime;
            timeDelay.text = "Starting in: " + Mathf.Round(time);
        }
        else
        {
            timeDelay.text = ""; //stop showing the countdown
            
            stepDisplay.text = "Steps: "+stepCounter;
            scoreDisplay.text = score.ToString();

            if (Input.GetKeyDown(KeyCode.Space)) //if you press space...
            {
                if (Mathf.Abs(tickTimer) > timerWindow / 2) //within the window
                {
                    abilityDisplay.text = "Good!"; //good job!
                    stepCounter++; //add to steps
                    score += 5; //+5 points
                }
                else //outside the window
                {
                    abilityDisplay.text = "Bad!"; //bad job :(
                    stepCounter++; //add to steps (for now)
                    ++failCounter; //add to fail counter - for some reason this doesnt work :/ tinker later...
                    
                }
                hit = true;
            }

            if (Mathf.Abs(tickTimer) >= bpmManager.BPS / 2) //within the timer window...
            {
                if (!hit) //if you dont press space at all
                {
                    failCounter++; //add to your fail amount
                    score -= 5;
                    abilityDisplay.text = "Miss!";
                }
                bpmManager.BPS = bpmManager.curBPM / 60; //sets the bpm (not entirely sure why this is needed but deleting it is bad so....)
                tickTimer = -bpmManager.BPS / 2; //sets the tick timer to have 0 as the middle (again idk why i need it here but u cant delete it..)

                hit = false;
            }
            if (failCounter >= 9) //if you fail above 8...
            {
                EndGame();
            }
            uiSecCount.text = (Mathf.Round(tickTimer * 100) / 100).ToString();
        }
    }
    public void EndGame()
    {
        Debug.Log("End Game");
        SceneManager.LoadScene(0);
    }
}
