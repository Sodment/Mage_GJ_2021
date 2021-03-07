using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveTimer : MonoBehaviour
{
    public Text timerText;
    float timer = 35.0f;
    int seconds;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        seconds = Mathf.RoundToInt(timer);
        SetTimerText();
        if (timer<=0.0f)
        {
            //EMIT EVENT FOR NEXT WAVE
            timer = 60.0f;
            Debug.Log("NEXT WAVE");
            EnemySpawner.instance.SpawnLevel();
        }
    }

    public void SetTimerText()
    {
        timerText.text = "NEXT WAVE:\n" + seconds.ToString();
    }
}
