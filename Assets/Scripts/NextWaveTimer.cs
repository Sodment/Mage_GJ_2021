using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveTimer : MonoBehaviour
{
    public Text timerText;
    float timer = 0.0f;
    int seconds;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        SetTimerText();
        if (seconds >= 60)
        {
            //EMIT EVENT FOR NEXT WAVE
            seconds = 0;
            Debug.Log("NEXT WAVE");
        }
    }

    public void SetTimerText()
    {
        timerText.text = "NEXT WAVE:\n" + (60 - seconds).ToString();
    }
}
