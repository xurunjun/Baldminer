using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreEvent : UnityEvent<int> { }
[DefaultExecutionOrder(-1)]
public class GameManager : Singleton<GameManager>
{
    [Header("随机种子")]
    public int seed;
    [Header("分数")]
    public int score;
    [Header("符号")]
    public string symbol;
    private int next;

    private UnityAction<int> action;

    private List<ScoreEvent> scoreEvent;
    private void Awake()
    {
        Random.InitState(seed);
        scoreEvent = new List<ScoreEvent>();
        scoreEvent.Add(new ScoreEvent());
        scoreEvent.Add(new ScoreEvent());
        scoreEvent.Add(new ScoreEvent());
        scoreEvent.Add(new ScoreEvent());
        scoreEvent[0].AddListener(addScroe);
        scoreEvent[1].AddListener(subScore);
        scoreEvent[2].AddListener(mulScore);
        scoreEvent[3].AddListener(divScore);
        nextScoreEvent();
    }

    private void addScroe(int score)
    {
        this.score += score;
    }

    private void subScore(int score)
    {
        this.score -= score;
    }

    private void mulScore(int score)
    {
        this.score*=score;
    }

    private void divScore(int score)
    {
        if(score==0)
        {
            score=1;
        }
        this.score/=score;
    }

    public void nextScoreEvent()
    {
        next = getRedom(0,scoreEvent.Count);
        setSymbol();
    }

    public void changeScore(int score)
    {
        scoreEvent[next].Invoke(score);
        nextScoreEvent();
    }

    public void setSymbol()
    {
        switch(next)
        {
            case 0:
            symbol="+";
            break;
            case 1:
            symbol="-";
            break;
            case 2:
            symbol="*";
            break;
            case 3:
            symbol="/";
            break;

        }
    }

    public int getRedom(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    public float getRedom(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }
}
