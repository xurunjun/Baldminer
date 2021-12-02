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

    public int AddScore;
    public int SubScore;
    public int MutiplyScore;
    public int DivitionScore;

    // Start is called before the first frame update
    void Start()
    {
        AddSlider.value = 0;
        SubSlider.value = 0;
        MutiplySlider.value = 0;
        DivitionSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AddSlider.value = AddScore;
        SubSlider.value = SubScore;
        MutiplySlider.value = MutiplyScore;
        DivitionSlider.value = DivitionScore;
    }
}
