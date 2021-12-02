using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text timeLeft;

    public StopBtn stopBtn;

    public float time = 60;
    public void TimeLeft()
    {
        if(stopBtn.StopEnable)
            time -= Time.deltaTime;  

        if (time < 0)
            time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft();
        timeLeft.text = time.ToString("0.00");
    }
    }
