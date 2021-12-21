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
    [Header("加法分数")]
    public int _addScore;
    [Header("减法分数")]
    public int _subScore;
    [Header("乘法分数")]
    public int _mulScore;
    [Header("除法分数")]
    public int _divScore;
    [Header("分数显示器")]
    public Score scoreShower;
    [Header("子弹显示器")]
    public BulletIcon bullet;
    private int next;
    public int _NEXT{
        get{
            return next;
        }
    }
    private UnityAction<int> action;

    private List<ScoreEvent> scoreEvent;
    private void Awake()
    {
        Random.InitState(seed);
        scoreEvent = new List<ScoreEvent>();
        Applicantion.targetFrameRate = 30;
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
        this.score += (int)(score*Player.Instance._Mage);
        _addScore+=score;
    }

    private void subScore(int score)
    {
        this.score -= (int)(score*Player.Instance._Mage);
        _subScore+=score;
    }

    private void mulScore(int score)
    {
        this.score*=(int)(score*Player.Instance._Mage);
        _mulScore+=score;
    }

    private void divScore(int score)
    {
        _divScore+=score;
        if(score==0)
        {
            score=1;
        }
        this.score/=(int)(score*Player.Instance._Mage);
    }

    public void nextScoreEvent()
    {
        next = getRedom(0,scoreEvent.Count);
        setSymbol();
        bullet.UpdateBulletImage(next);
    }

    public void changeScore(int score)
    {
        scoreEvent[next].Invoke(score);
        scoreShower.setScore(this.score);
        nextScoreEvent();
        bullet.UpdateBulletImage(next);
        updatePlayer();
    }

    public void updatePlayer()
    {
        if(_addScore>Player.Instance.getCost(Player.LevelType.SPEED))
        {
            _addScore=0;
            Player.Instance.LevelUp(Player.LevelType.SPEED);
        }
        if(_subScore>Player.Instance.getCost(Player.LevelType.SIZE))
        {
            _subScore=0;
            Player.Instance.LevelUp(Player.LevelType.SIZE);
        }
        if(_mulScore>Player.Instance.getCost(Player.LevelType.MAGN))
        {
            _mulScore=0;
            Player.Instance.LevelUp(Player.LevelType.MAGN);
        }
        if(_divScore>Player.Instance.getCost(Player.LevelType.COST))
        {
            _divScore=0;
            Player.Instance.LevelUp(Player.LevelType.COST);
        }
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
