using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject EndGameCanvas;

    public Text timeLeft;
    public StopBtn stopBtn;

    public float time = 60;
    public void TimeLeft()
    {
        if(stopBtn.StopWindow.activeSelf == false)
            time -= Time.deltaTime;

        if (time <= 0)
        {
            stopBtn.Generater.SetActive(false);
            EndGameCanvas.SetActive(true);
            time = 0;
        }
        else
            EndGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft();
        timeLeft.text = time.ToString("0.00");
    }
    }
