using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    [Header("种子")]
    public int seed;
    private GameObject bullet;
    [Header("子弹列表")]
    public List<GameObject> bulletList;
    [Header("起始位置")]
    public Vector2 startPosition;
    [Header("最大高度")]
    public float maxY;
    [Header("目标位置")]
    public Vector2 targetPosition;
    [Header("基础花费")]
    public List<int> costList;
    [Header("速度等级")]
    public List<float> speedLevel;
    [Header("大小等级")]
    public List<float> sizeLevel;
    [Header("倍率等级")]
    public List<float> MagnLevel;
    [Header("花费等级")]
    public List<float> costLevel;
    [Header("当前速度")]
    public float currentSpeed;
    [Header("当前大小")]
    public float currentSize;
    [Header("当前倍率")]
    public float currentMagn;
    [Header("当前花费")]
    public float currentCost;
    private Vector2 direction;
    public bool isFire;
    public bool isBack;

    [Header("加法等级")]
    public int _addLevel;
    [Header("减法等级")]
    public int _subLevel;
    [Header("乘法等级")]
    public int _mulLevel;
    [Header("除法等级")]
    public int _divLevel;
    [Header("激光")]
    public Laser laser;
    [Header("游戏管理器")]
    public GameManager gameManager;

    public bool isLaser = false;

    private bool isFever = false;

    public float _Mage
    {
        get
        {
            return currentMagn;
        }
    }

    public enum LevelType
    {
        SPEED,
        SIZE,
        MAGN,
        COST
    }

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    public void getVelocity(Vector2 value)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(value);
        if (pos.y > maxY)
        {
            direction = Vector2.down;
        }
        else
        {
            direction = (pos - startPosition).normalized;
        }
    }

    public void switchFever(bool isFever)
    {
        this.isFever = isFever;
    }

    public void startAccumulate()
    {
        if (isFever && !isFire)
        {
            isLaser = true;
            laser.startAccumulate();
        }
    }

    public void finishAccumulate()
    {
        laser.finishAccumulate();
    }

    public void cancelAccumulate(Vector2 screenPosition, float duration)
    {
        getVelocity(screenPosition);
        laser.shotLaser(direction, duration);
    }

    public void Fire(Vector2 screenPosition, InputAction.CallbackContext context)
    {
        if (!isFever)
        {
            getVelocity(screenPosition);
            shotBullet();
        }
    }

    private void shotBullet()
    {
        if (!isBack && !isFire && !isLaser)
        {
            isFire = true;
            bullet = ObjectPool.Instance.GetObject(bulletList[0]);
            bullet.transform.position = startPosition;
            bullet.GetComponent<AddBullet>().startFly(currentSpeed, direction, currentSize);

            isFire = true;
        }
    }

    public void LevelUp(LevelType type)
    {
        int index;
        switch (type)
        {
            case LevelType.SPEED:
                index = speedLevel.IndexOf(currentSpeed) + 1;

                if (index < speedLevel.Count)
                {
                    _addLevel = index;
                    currentSpeed = speedLevel[index];
                }
                break;
            case LevelType.SIZE:
                index = sizeLevel.IndexOf(currentSize) + 1;

                if (index < sizeLevel.Count)
                {
                    _subLevel = index;
                    currentSize = sizeLevel[index];
                }
                break;
            case LevelType.MAGN:
                index = MagnLevel.IndexOf(currentMagn) + 1;

                if (index < MagnLevel.Count)
                {
                    _mulLevel = index;
                    currentMagn = MagnLevel[index];
                }
                break;
            case LevelType.COST:
                index = costLevel.IndexOf(currentCost) + 1;

                if (index < costLevel.Count)
                {
                    _divLevel = index;
                    currentCost = costLevel[index];
                }
                break;
        }
    }

    public int getCost(LevelType type)
    {
        switch (type)
        {
            case LevelType.SPEED:
                return (int)(costList[speedLevel.IndexOf(currentSpeed)] * currentCost);
            case LevelType.SIZE:
                return (int)(costList[sizeLevel.IndexOf(currentSize)] * currentCost);
            case LevelType.MAGN:
                return (int)(costList[MagnLevel.IndexOf(currentMagn)] * currentCost);
            case LevelType.COST:
                return (int)(costList[costLevel.IndexOf(currentCost)] * currentCost);
        }
        return costList[costList.Count - 1];
    }

    public void reStart()
    {
        currentSpeed = 1.4f;
        currentSize = 1;
        currentMagn = 1;
        currentCost = 1;

        gameManager.score = 0;
        gameManager._addScore = 0;
        gameManager._subScore = 0;
        gameManager._mulScore = 0;
        gameManager._divScore = 0;

        _addLevel = 0;
        _subLevel = 0;
        _mulLevel = 0;
        _divLevel = 0;
    }

    public void RestartGame()
    {
        isFire = false;
        isBack = false;
        isLaser = false;
    }
}
