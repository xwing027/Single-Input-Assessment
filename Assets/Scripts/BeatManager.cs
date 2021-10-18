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
    //bool isCounting = false;
    public float tickTimer;
    float timerWindow = .2f; //sets the window for when to press, currently same window regardless of bpm

    bool hit;

    public Text uiBeatCount;

    float failCounter;
    #endregion

    private void Start()
    {
        bpmManager = GetComponent<BPMManager>();

        bpmManager.BPS = bpmManager.curBPM / 60;
        tickTimer = -bpmManager.BPS / 2;

        bpmManager.HundredBeat();

        //PlayerPrefs.Save();
    }

    private void Update()
    {
        //regulates the tick timer
        tickTimer += Time.deltaTime;

        if (tickTimer >= bpmManager.BPS / 2) //this sets up the timer with 0 as the middle 
        {
            //bpmManager.BPS = bpmManager.curBPM / 60;
            tickTimer = -bpmManager.BPS / 2;
        }

        uiBeatCount.text = (Mathf.Round(tickTimer * 100) / 100).ToString();

        //determines how far off 0 you are
        if (Mathf.Abs(tickTimer) > timerWindow / 2) //this is the window you have to press space
        {
            if (!hit)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Yay!");
                    hit = true;
                }
                else
                {
                    //Debug.Log("You were " + tickTimer + " seconds off.");

                    if (!hit) //if you fail to press on time
                    {

                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hit = true;
                Debug.Log("bad timing");
                failCounter++;
            }
            if (tickTimer >= -bpmManager.BPS / 2)
            {
                if (hit == false)
                {
                    failCounter = 5;
                    Debug.Log("miss");
                }
                hit = false;


            }
        }
        if (failCounter >= 5) //if you miss 5 or more times
        {
            EndGame(); //end
        }
    }
        void EndGame()
        {
            //go to main menu
            Debug.Log("End Game");
            SceneManager.LoadScene(0);
        }

        /*public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Zone"))
            {
                //currentZone = other.transform;
            }
        }

        public IEnumerator Count()
        {
            isCounting = true;

            while (isCounting)
            {
                if (bpmManager.beatCount < 4)
                {
                    bpmManager.beatCount++;
                    Debug.Log(bpmManager.beatCount);
                    uiBeatCount.text = "Beat: " + bpmManager.beatCount;
                    yield return new WaitForSeconds(bpmManager.BPS);
                }
                if (bpmManager.beatCount == 4)
                {
                    bpmManager.beatCount = 1;
                    Debug.Log(bpmManager.beatCount);
                    uiBeatCount.text = "Beat: " + bpmManager.beatCount;
                    yield return new WaitForSeconds(bpmManager.BPS);
                }
            }
        }*/
    
}
