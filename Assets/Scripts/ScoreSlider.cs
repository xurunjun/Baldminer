using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    public Slider AddSlider;
    public Slider SubSlider;
    public Slider MutiplySlider;
    public Slider DivitionSlider;
    public Slider GoldSlider;

    public Image AddImage;
    public Image SubImage;
    public Image MutiplyImgae;
    public Image DivitionImage;
    public Color[] ImageColor = {new Color(0.1f,1.0f,1.0f), new Color(1.0f, 0.1f, 1.0f) ,
        new Color(1.0f, 1.0f, 0.1f), new Color(0.1f, 1.0f, 1.0f), new Color(0.1f, 0.1f, 0.1f) , new Color(0.1f, 0.1f, 0.1f) };

    public GameManager gameManager;
    public Player player;
    public SoundSetting soundSetting;

    // Start is called before the first frame update
    public void Start()
    {
        AddSlider.value = 0;
        SubSlider.value = 0;
        MutiplySlider.value = 0;
        DivitionSlider.value = 0;
        GoldSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreSliderManager();


        if (Time.time * 10 % 2 < 1 && GoldSlider.value == GoldSlider.maxValue)
            GoldSlider.gameObject.SetActive(false);
        else
        {
            soundSetting.audioSource.pitch = 1 + GoldSlider.value/GoldSlider.maxValue;
            GoldSlider.gameObject.SetActive(true);
        }
    }

    void ScoreSliderManager()
    {
        
        AddSlider.maxValue = player.costList[player._addLevel];
        SubSlider.maxValue = player.costList[player._subLevel];
        MutiplySlider.maxValue = player.costList[player._mulLevel];
        DivitionSlider.maxValue = player.costList[player._divLevel];

        AddImage.color = ImageColor[player._addLevel];
        SubImage.color = ImageColor[player._subLevel];
        MutiplyImgae.color = ImageColor[player._mulLevel];
        DivitionImage.color = ImageColor[player._divLevel];
        
        if(gameManager._addScore <= AddSlider.maxValue)
            AddSlider.value = gameManager._addScore;
        if (gameManager._subScore <= SubSlider.maxValue)
            SubSlider.value = gameManager._subScore;
        if (gameManager._mulScore <= MutiplySlider.maxValue)
            MutiplySlider.value = gameManager._mulScore;
        if (gameManager._divScore <= DivitionSlider.maxValue)
            DivitionSlider.value = gameManager._divScore;
        if (gameManager._FeverNum <= GoldSlider.maxValue)
            GoldSlider.value = gameManager._FeverNum;

        if (gameManager.isFever)
            GoldSlider.value = 20;
        GoldSlider.value = gameManager._FeverNum;



    }

}
