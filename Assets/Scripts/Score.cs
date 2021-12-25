using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scorenum;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Scorenum.text = "0";
    }

    public void setScore(int score)
    {
        if (score > 999999999)
            score = 999999999;
        Scorenum.text=score.ToString();
        this.score=score;
    }
}
