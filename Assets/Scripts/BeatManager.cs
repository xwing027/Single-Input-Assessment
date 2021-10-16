using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    #region Variables
    float curBPM = 100;
    int beatCount;
    float BPS;
    float zoneBeat;
    bool isCounting = false;
    float tickTimer;
    float timerWindow = .2f;

    bool hit;
    
    public Text uiBeatCount;

    float failCounter;
    #endregion

    private void Start()
    {
        BPS = curBPM / 60;
        tickTimer = -BPS/2;

        //PlayerPrefs.Save();
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(tickTimer) > timerWindow/2)
            {
                Debug.Log("Yay!");
            }
            else
            {
                Debug.Log("You were " + tickTimer + " seconds off.");                          
            }
            hit = true;
        }
        
        if(tickTimer>= BPS/2)
        {
            if (!hit)
            {
                failCounter++;

                if (failCounter >= 5)
                {
                    Missed();
                }
                if (failCounter < 5)
                {
                    Debug.Log("Bad!");
                }
            }
            BPS = curBPM / 60;
            tickTimer = -BPS/2;

            hit = false;
        }
        uiBeatCount.text = (Mathf.Round(tickTimer * 100) / 100).ToString();
    }

    void Missed()
    {
        //if failed 5 times in a row
        Debug.Log("End Game");
    }

    public void HundredBeat()
    {
        curBPM = 100.0f;
        BPS = curBPM / 60.0f;
        Debug.Log(BPS);

        beatCount = 0;

        StartCoroutine("Count");
    }

    public IEnumerator Count()
    {
        isCounting = true;

        while (isCounting)
        {
            if (beatCount < 4)
            {
                beatCount++;
                Debug.Log(beatCount);
                uiBeatCount.text = "Beat: " + beatCount;
                yield return new WaitForSeconds(BPS);
            }
            if (beatCount == 4)
            {
                beatCount = 1;
                Debug.Log(beatCount);
                uiBeatCount.text = "Beat: " + beatCount;
                yield return new WaitForSeconds(BPS);
            }
        }
    }
}
