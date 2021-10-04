using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    float curBPM;
    int beatCount;
    float BPS;
    float zoneBeat;
    bool isCounting = false;
    
    public Text uiBeatCount;

    //WaitForSeconds delay = new WaitForSeconds(1.67f);

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
