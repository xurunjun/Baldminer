using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public GameObject player;
    public GameObject GenerateManager;
    public GameObject StartGameCanvas;
    public GameObject SoundSetting;

    public StopBtn stopBtn;
    public Countdown countdown;


    public void Start()
    {
        stopBtn.StopEnable = false;
        SoundSetting.SetActive(false);
        StartGameCanvas.SetActive(true);
        player.SetActive(false);
        GenerateManager.SetActive(false);
        gameObject.SetActive(true);

        countdown.time = 60;
    }
    public void StartGameBtn()
    {
        Debug.Log("yesman");
        player.SetActive(true);
        GenerateManager.SetActive(true);
        gameObject.SetActive(false);
        stopBtn.StopEnable = true;
    }


}
