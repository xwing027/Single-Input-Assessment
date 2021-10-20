using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPMManager : MonoBehaviour
{
    public float curBPM;
    public float BPS;
    public int beatCount;
    bool isCounting = false;
    BeatManager beatManager;
    public bool isHundred = false;

    public Text uiBeatCount;

    public void HundredBeat()
    {
        curBPM = 100.0f;
        BPS = curBPM / 60.0f;
        Debug.Log(BPS);

        beatCount = 0;

        StartCoroutine("Count");
    }

    public void OneTwentyBeat()
    {
        curBPM = 120.0f;
        BPS = curBPM / 60.0f;
        Debug.Log("BPM is now 120");

        beatCount = 0;

        //StartCoroutine("Count");
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
