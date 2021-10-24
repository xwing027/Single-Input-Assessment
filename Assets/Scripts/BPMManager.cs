using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BPMManager : MonoBehaviour
{
    #region Variables
    public float curBPM;
    public float BPS;
    public int beatCount;
    bool isCounting = false;
    
    public string speed;
    public bool isOneTwenty = false;

    BeatManager beatManager;
    public GameObject chonk;
    public GameObject chonk2;
    public GameObject chonk3;
    public GameObject lanky;
    public GameObject lanky2;
    public GameObject spook;

    public Text uiBeatCount;
    public Text speedDisplay;

    AudioSource claps;
    #endregion 

    public void Start()
    {
        claps = GetComponentInParent<AudioSource>();
    }

    public void HundredBeat()
    {
        if (!isOneTwenty)
        {
            speed = "Med";

            curBPM = 100.0f;
            BPS = curBPM / 60.0f;
            Debug.Log(BPS);
            speedDisplay.text = "Speed: " + speed;

            beatCount = 0;

            StartCoroutine(Delay());
        }
        else
        {
            return;
        }
    }

    public void OneTwentyBeat()
    {
        speed = "Fast";
        isOneTwenty = true;
        curBPM = 120.0f;
        BPS = curBPM / 60.0f;
        speedDisplay.text = "Speed: " + speed;
        Debug.Log("BPM is now 120");

        StartCoroutine(Count(0f));
    }

    public IEnumerator Delay()
    {
        yield return StartCoroutine(Count(25f));
    }

    public IEnumerator Count(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isCounting = true;
        while (isCounting)
        {
            
            if (beatCount < 4)
            {
                beatCount++;
                Debug.Log(beatCount);
                uiBeatCount.text = "Beat: " + beatCount;
                claps.Play();
                chonk.GetComponentInChildren<Animator>().SetTrigger("Clap");
                chonk2.GetComponentInChildren<Animator>().SetTrigger("Clap");
                chonk3.GetComponentInChildren<Animator>().SetTrigger("Clap");
                lanky2.GetComponentInChildren<Animator>().SetTrigger("Clap");
                spook.GetComponentInChildren<Animator>().SetTrigger("Clap");
                lanky.GetComponentInChildren<Animator>().SetTrigger("Clap");
                yield return new WaitForSeconds(BPS);
            }
            if (beatCount == 4)
            {
                beatCount = 1;
                Debug.Log(beatCount);
                uiBeatCount.text = "Beat: " + beatCount;
                claps.Play();
                chonk.GetComponentInChildren<Animator>().SetTrigger("Clap");
                chonk2.GetComponentInChildren<Animator>().SetTrigger("Clap");
                chonk3.GetComponentInChildren<Animator>().SetTrigger("Clap");
                lanky2.GetComponentInChildren<Animator>().SetTrigger("Clap");
                spook.GetComponentInChildren<Animator>().SetTrigger("Clap");
                lanky.GetComponentInChildren<Animator>().SetTrigger("Clap");
                yield return new WaitForSeconds(BPS);
            }
        }
    }
}
