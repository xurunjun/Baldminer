using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Player player;
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
        player.gameObject.SetActive(false);
        GenerateManager.SetActive(false);
        gameObject.SetActive(true);
        player.reStart();

        countdown.time = 120;
    }
    public void StartGameBtn()
    {
        player.gameObject.SetActive(true);
        GenerateManager.SetActive(true);
        gameObject.SetActive(false);
        stopBtn.StopEnable = true;
    }


}
