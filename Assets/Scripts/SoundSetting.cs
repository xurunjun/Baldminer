using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Slider soundSlider;
    public Toggle bgmtoggle;
    public AudioSource audioSource;
    public AudioSource fireSource;
    public AudioSource backSource;
    public GameObject soundsetting;
    public Player player;

    bool lastFire = false;
    bool lastBack;

    // Start is called before the first frame update

    private void Start()
    {
        soundSlider.value = 1;
        bgmtoggle.isOn = true;
    }


    public void Update()
    {
        if(player.isFire && !lastFire)
            Sound(fireSource.clip);

        if (!player.isBack && lastBack)
            Sound(backSource.clip);
        lastBack = player.isBack;
        lastFire = player.isFire;
    }
    public void SoundSlider()
    {
        audioSource.volume = soundSlider.value;
    }

    public void BGMToggle()
    {
        if (bgmtoggle.isOn)
        {
            audioSource.gameObject.SetActive(true);
            SoundSlider();
        }
        else
            audioSource.gameObject.SetActive(false);
    }

    public void SoundBtn()
    {
        soundsetting.SetActive(true);
    }


    public void SounddispBtn()
    {
        soundsetting.SetActive(false);
    }

    public void Sound(AudioClip audioClip)
    {
        fireSource.PlayOneShot(audioClip);
    }
}
