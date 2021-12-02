using System.Collections.Generic;
using UnityEngine;

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

    public float _Mage{
        get{
            return currentMagn;
        }
    }

    public enum LevelType{
        SPEED,
        SIZE,
        MAGN,
        COST
    }

    private InputManager inputManager;

    private void Awake() {
        inputManager = InputManager.Instance;
    }
    void Start()
    {
    }
    private void OnEnable() {
        inputManager.onEndTouch+=Fire;
    }

    private void OnDisable() {
        inputManager.onEndTouch -=Fire;
    }

    public void getVelocity(Vector2 value)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(value);
        if(pos.y>maxY)
        {
            pos.y=maxY;
        }
        direction=(pos-startPosition).normalized;
    }

    public void Fire(Vector2 screenPosition,float time)
    {
        if(!isBack&&!isFire)
        {
            getVelocity(screenPosition);
            bullet = ObjectPool.Instance.GetObject(bulletList[GameManager.Instance.getRedom(0,bulletList.Count)]);
            bullet.transform.position = startPosition;
            bullet.GetComponent<AddBullet>().startFly(currentSpeed,direction,currentSize);

            isFire=true;
        }
    }

    public void LevelUp(LevelType type)
    {
        int index;
        switch(type)
        {
            case LevelType.SPEED:
            index = speedLevel.IndexOf(currentSpeed)+1;
            if(index<speedLevel.Count)
                currentSpeed=speedLevel[index];
            break;
            case LevelType.SIZE:
            index = sizeLevel.IndexOf(currentSize)+1;
            if(index<sizeLevel.Count)
                currentSize=sizeLevel[index];
            break;
            case LevelType.MAGN:
            index = MagnLevel.IndexOf(currentMagn)+1;
            if(index<MagnLevel.Count)
                currentMagn=MagnLevel[index];
            break;
            case LevelType.COST:
            index = costLevel.IndexOf(currentCost)+1;
            if(index<costLevel.Count)
                currentCost=costLevel[index];
            break;
        }
    }

    public int getCost(LevelType type)
    {
        switch(type)
        {
            case LevelType.SPEED:
            return (int)(costList[speedLevel.IndexOf(currentSpeed)]*currentCost);
            case LevelType.SIZE:
            return (int)(costList[sizeLevel.IndexOf(currentSize)]*currentCost);
            case LevelType.MAGN:
            return (int)(costList[MagnLevel.IndexOf(currentMagn)]*currentCost);
            case LevelType.COST:
            return (int)(costList[costLevel.IndexOf(currentCost)]*currentCost);
        }
        return costList[costList.Count-1];
    }
}
