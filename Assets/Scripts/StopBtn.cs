using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtn : MonoBehaviour
{
    public GameObject StopWindow;
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
        StopEnable = false;
    }

    public void ContinueBtnOnClick()
    {
        audioSource.gameObject.SetActive(true);
        StopWindow.SetActive(false);
        StopEnable = true;
    }
}
