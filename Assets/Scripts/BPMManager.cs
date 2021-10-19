using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMManager : MonoBehaviour
{
    public float curBPM;
    public float BPS;
    public int beatCount;

    public void HundredBeat()
    {
        curBPM = 100.0f;
        BPS = curBPM / 60.0f;
        Debug.Log(BPS);

        beatCount = 0;

        //StartCoroutine("Count");
    }

    public void OneTwentyBeat()
    {
        curBPM = 120.0f;
        BPS = curBPM / 60.0f;
        Debug.Log("BPM is now 120");

        beatCount = 0;
    }
}
