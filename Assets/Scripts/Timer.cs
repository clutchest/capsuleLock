using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float timeCount = 0f; //minute

    private void Start()
    {
        timeCount *= 60; //pretvorili smo u sekunde
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= 0)
        {
            //Dijlimo sa cijelim brojem da dobijemo minute
            int minutes = (int)(timeCount / 60);
            //Dijelimo sa 60 dadobijemo ostatak (% sluzi za dijeljenje sa ostatkom)
            int seconds = Mathf.FloorToInt(timeCount % 60);
            //Ako je manje od 10 brojcano za minute i sekunde
            if (minutes < 10 && seconds < 10)
            {
                timerText.text = "0" + minutes + ":" + "0" + seconds;
            }
            //Minute su jednoznamenkaste, ali sekunde su dvoznamenkaste
            else if (minutes < 10 && seconds >= 10)
            {
                timerText.text = "0" + minutes + ":" + seconds;
            }
            //Minute su dvoznamekaste, ali sekunde su jednoznamenkaste
            else if (minutes >= 10 && seconds < 10)
            {
                timerText.text = minutes + ": 0" + seconds;
            }
            //Minute i sekunde su nam dvoznamenkaste
            else
            {
                timerText.text = minutes + ":" + seconds;
            }
        }
    }
}
