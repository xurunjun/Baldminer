using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class StopBtn : MonoBehaviour
{
    public GameObject StopWindow;
    public GameObject Player;
    public GameObject Generater;

    public SoundSetting soundSetting;
    public PlayerInput inputManager;

    public AudioSource audioSource;


    public bool StopEnable;

    public void Start()
    {
        StopWindow.SetActive(false);
        StopEnable = true;
    }
    public void StopBtnOnClick()
    {
        audioSource.gameObject.SetActive(false);
        StopWindow.SetActive(true);
        Player.SetActive(false);
        Generater.SetActive(false);
        StopEnable = false;
        inputManager.enabled = false;
    }

    public void ContinueBtnOnClick()
    {
        if(soundSetting.bgmtoggle.isOn)
            audioSource.gameObject.SetActive(true);

        Player.SetActive(true);
        Generater.SetActive(true);
        StopWindow.SetActive(false);
        StopEnable = true;
        inputManager.enabled = true;
    }
}
