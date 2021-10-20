using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{
    #region Variables
    private BPMManager bpmManager;

    float zoneBeat;
    public float tickTimer;
    float timerWindow = .2f; //sets the window for when to press, currently same window regardless of bpm

    bool hit;

    public Text uiSecCount;
    public Text timeDelay;
    public Text abilityDisplay;

    float failCounter;

    public float time = 3.0f;
    #endregion

    private void Start()
    {
        bpmManager = GetComponent<BPMManager>();

        bpmManager.BPS = bpmManager.curBPM / 60;
        tickTimer = -bpmManager.BPS / 2;

        //PlayerPrefs.Save();
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
            timeDelay.text = "";
            bpmManager.HundredBeat();
            if (Input.GetKeyDown(KeyCode.Space)) //if you press space...
            {
                if (Mathf.Abs(tickTimer) > timerWindow / 2) //within the window
                {
                    abilityDisplay.text = "Good!"; //good job!
                }
                else //outside the window
                {
                    abilityDisplay.text = "Bad!"; //bad job :(
                }
                hit = true;
            }

        if (tickTimer >= bpmManager.BPS / 2) //within the timer window...
        {
            if (!hit) //if you dont press space at all
            {
                failCounter++; //add to your fail amount

                if (failCounter >= 5) //if you fail above 4...
                {
                    EndGame(); 
                }
                if (failCounter < 5) //if you fail below 4...
                {
                    abilityDisplay.text = "Miss!"; //you miss!
                }
            }
            
            bpmManager.BPS = bpmManager.curBPM / 60; //sets the bpm (not entirely sure why this is needed but deleting it is bad so....
            tickTimer = -bpmManager.BPS / 2; //sets the tick timer to have 0 as the middle (again idk why i need it here but u cant delete it..)

            hit = false;
        }
        uiSecCount.text = (Mathf.Round(tickTimer * 100) / 100).ToString();
        }
    }


    void EndGame()
    {
        //go to main menu
        Debug.Log("End Game");
        SceneManager.LoadScene(0);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Zone1")) //when you enter a new zone
        {
            //currentZone = nextZone
            //nextZone = newZoneObject at x coordinates at the end of current zone
            //change bpm
            //
        }
    }
}
