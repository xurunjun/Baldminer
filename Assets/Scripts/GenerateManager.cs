using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    [Header("随机种子")]
    public int seed;

    [Header("生成最大范围二分之一宽度")]
    public int maxWidth;

    [Header("生成最大范围二分之一高度")]
    public int maxHight;

    [Header("生成基数")]
    public int baseNum;

    [Header("锚点横坐标")]
    public int anchorX;

    [Header("锚点纵坐标")]
    public int anchorY;

    [Header("生成元素列表")]
    public List<GameObject> Elements;

    [Header("起始元素索引")]
    public int startIndex;

    [Header("增长因子")]
    public float growFactor;

    [Header("最大生成上限")]
    public int maxItem;

    private float timer=0;

    private int itemNum=0;

    private void Awake() {
        Random.InitState(seed);
    }

    bool nextTimer(float deltaTime)
    {
        timer+=deltaTime;
        if(timer>3)
        {
            return true;
        }
        return false;
    }

    bool reachMaxItem()
    {
        if(itemNum<maxItem)
        {
            return true;
        }
        return false;
    }

    void clearTimer()
    {
        timer=0;
    }

    int getIndex()
    {
        return Random.Range(0,Elements.Count);
    }

    Vector3 getElementPosition()
    {
        return new Vector3(Random.Range(-maxWidth,maxWidth)+anchorX,
        Random.Range(-maxHight,maxHight)+anchorY,-2);
    }

    // Update is called once per frame
    void Update()
    {
        if(reachMaxItem()&&nextTimer(Time.deltaTime))
        {
            GameObject _Instance = Instantiate(Elements[getIndex()],getElementPosition(),Quaternion.identity);
            _Instance.transform.parent = this.transform;
            clearTimer();
            itemNum++;
        }
    }
}
