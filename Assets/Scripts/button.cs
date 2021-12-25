using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class button : MonoBehaviour
{
    public Player player;
    public GameObject GenerateManager;
    public GameObject StartGameCanvas;
    public GameObject EndGameCanvas;
    public PlayerInput inputManager;

    public StopBtn stopBtn;
    public Countdown countdown;
    public SoundSetting soundSetting;
    public GameManager gameManager;
    public EndGame endGame;


    public void Start()
    {
        stopBtn.StopEnable = false;

        soundSetting.gameObject.SetActive(false);
        StartGameCanvas.SetActive(true);
        player.gameObject.SetActive(false);
        GenerateManager.SetActive(false);
        gameObject.SetActive(true);
        EndGameCanvas.SetActive(false);
        inputManager.enabled = false;
        player.reStart();

        countdown.time = 120;
    }
    public void StartGameBtn()
    {
        stopBtn.StopEnable = true;

        GenerateManager.SetActive(true);
        gameObject.SetActive(false);
        EndGameCanvas.SetActive(false);
        stopBtn.StopWindow.SetActive(false);

        if (soundSetting.bgmtoggle.isOn)
            soundSetting.audioSource.gameObject.SetActive(true);

        endGame.RestartBtnOnClick();
        player.gameObject.SetActive(true);
        inputManager.enabled = true;
    }


}
