using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Player player;
    public GameObject GenerateManager;
    public GameObject StartGameCanvas;

    public StopBtn stopBtn;
    public Countdown countdown;
    public SoundSetting soundSetting;


    public void Start()
    {
        stopBtn.StopEnable = false;

        soundSetting.gameObject.SetActive(false);
        StartGameCanvas.SetActive(true);
        player.gameObject.SetActive(false);
        GenerateManager.SetActive(false);
        gameObject.SetActive(true);
        player.reStart();

        countdown.time = 120;
    }
    public void StartGameBtn()
    {
        stopBtn.StopEnable = true;

        player.gameObject.SetActive(true);
        GenerateManager.SetActive(true);
        gameObject.SetActive(false);
        stopBtn.StopWindow.SetActive(false);

        if (soundSetting.bgmtoggle.isOn)
            soundSetting.audioSource.gameObject.SetActive(true);
    }


}
