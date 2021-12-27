using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ScoreEvent : UnityEvent<int> { }
[System.Serializable]
public class FeverEvent : UnityEvent<bool> { }
[DefaultExecutionOrder(-1)]
public class GameManager : Singleton<GameManager>
{
    [Header("随机种子")]
    public int seed;
    [Header("分数")]
    public int score;
    [Header("最大分数")]
    public int maxScore;
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
    [Header("Fever花费")]
    public int FeverCost;
    [Header("Fever时间")]
    public int FeverTime;
    private int feverNum;

    public int _FeverNum
    {
        get
        {
            return feverNum;
        }
        set
        {
            feverNum += value;
            if (feverNum >= FeverCost)
            {
                _Fever = true;
                feverNum = 0;
            }
        }
    }
    [Header("分数显示器")]
    public Score scoreShower;
    [Header("子弹显示器")]
    public BulletIcon bullet;
    public UnityEvent restartEvent;
    private int next;
    public int _NEXT
    {
        get
        {
            return next;
        }
    }
    public bool isFever = false;

    public int _Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value <= maxScore)
                score = value;
        }
    }

    public bool _Fever
    {
        get
        {
            return isFever;
        }
        set
        {
            isFever = value;
            if (value)
            {
                endFever();
            }
            else
            {
                feverNum = 0;
            }
            feverEvent.Invoke(value);
        }
    }

    public FeverEvent feverEvent;

    private async void endFever()
    {
        await Task.Delay(FeverTime * 1000);
        _Fever = false;
    }

    private List<ScoreEvent> scoreEvent;
    private void Awake()
    {
        UnityEngine.Random.InitState(seed);
        Application.targetFrameRate = 30;
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

    public void RandomSeed()
    {
        seed = (int)(DateTime.Now.Ticks % 1000);
        UnityEngine.Random.InitState(seed);
    }

    public void RestartGame()
    {
        _Fever = false;
        restartEvent.Invoke();
    }

    public void addScroe(int score)
    {
        _Score += (int)(score + Player.Instance._Mage);
        _addScore += score;
    }

    public void subScore(int score)
    {
        _Score -= (int)(score - Player.Instance._Mage);
        _subScore += score;
    }

    public void mulScore(int score)
    {
        _Score *= (int)(score * Player.Instance._Mage);
        _mulScore += score;
    }

    public void divScore(int score)
    {
        _divScore += score;
        _addScore += score;
        _subScore += score;
        _mulScore += score;
        score = (int)(score / Player.Instance._Mage);
        if (score == 0)
        {
            score = 1;
        }
        _Score /= score;
    }

    public void nextScoreEvent()
    {
        next = getRedom(0, scoreEvent.Count);
        setSymbol();
        // bullet.UpdateBulletImage(next);
    }

    public void changeScore(int score)
    {
        scoreEvent[next].Invoke(score);
        scoreShower.setScore(this.score);
        nextScoreEvent();
        bullet.UpdateBulletImage(next);
        updatePlayer();
        _FeverNum = 1;
    }

    public void addScoreInFever(int score)
    {
        _Score += score;
        _addScore += 1;
        _subScore += 1;
        _mulScore += 1;
        scoreShower.setScore(this.score);
        updatePlayer();
    }

    public void updatePlayer()
    {
        if (_addScore > Player.Instance.getCost(Player.LevelType.SPEED))
        {
            _addScore = 0;
            Player.Instance.LevelUp(Player.LevelType.SPEED);
        }
        if (_subScore > Player.Instance.getCost(Player.LevelType.SIZE))
        {
            _subScore = 0;
            Player.Instance.LevelUp(Player.LevelType.SIZE);
        }
        if (_mulScore > Player.Instance.getCost(Player.LevelType.MAGN))
        {
            _mulScore = 0;
            Player.Instance.LevelUp(Player.LevelType.MAGN);
        }
        if (_divScore > Player.Instance.getCost(Player.LevelType.COST))
        {
            _divScore = 0;
            Player.Instance.LevelUp(Player.LevelType.COST);
        }
    }

    public void setSymbol()
    {
        switch (next)
        {
            case 0:
                symbol = "+";
                break;
            case 1:
                symbol = "-";
                break;
            case 2:
                symbol = "*";
                break;
            case 3:
                symbol = "/";
                break;

        }
    }

    public int getRedom(int minValue, int maxValue)
    {
        return UnityEngine.Random.Range(minValue, maxValue);
    }

    public float getRedom(float minValue, float maxValue)
    {
        return UnityEngine.Random.Range(minValue, maxValue);
    }
}
