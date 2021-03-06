using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : Singleton<GenerateManager>
{

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

    [Header("锚点Z坐标")]
    public int anchorZ;

    [Header("生成元素列表")]
    public List<GameObject> Elements;

    [Header("起始元素索引")]
    public int startIndex;

    [Header("增长因子")]
    public float growFactor;

    [Header("最大生成上限")]
    public int maxItem;
    [Header("分数列表")]
    public List<int> numList;
    [Header("生成间隔")]
    public float time;
    private float timer = 0;
    [Header("当前物体数量")]
    public int itemNum = 0;

    [Header("轨道")]
    public RailController rail;

    private bool isFever = false;

    private void Start()
    {
        StartCoroutine("brithNumbers");
    }

    public void Fever(bool value)
    {
        if (value)
        {
            isFever = true;
            StopCoroutine("brithNumbers");
            clearAllChildrenObject();
            rail.isStop = false;
            rail.startToBrith();
        }
        else
        {
            isFever = false;
            rail.stop();
            addNumbers();
        }
    }
    bool nextTimer(float deltaTime)
    {
        timer += deltaTime;
        if (timer > time)
        {
            return true;
        }
        return false;
    }

    bool reachMaxItem()
    {
        if (itemNum < maxItem)
        {
            return true;
        }
        return false;
    }

    void clearTimer()
    {
        timer = 0;
    }

    Vector3 getElementPosition()
    {
        return new Vector3(Random.Range(-maxWidth, maxWidth) + anchorX,
        Random.Range(-maxHight, maxHight) + anchorY, anchorZ);
    }

    private IEnumerator brithNumbers()
    {
        while (reachMaxItem())
        {
            if (nextTimer(Time.deltaTime))
            {
                GameObject _Instance = ObjectPool.Instance.GetObject(Elements[GameManager.Instance.getRedom(0, Elements.Count)]);
                _Instance.transform.position = getElementPosition();
                _Instance.transform.parent = this.transform;
                _Instance.GetComponent<Number>().setScore(numList[GameManager.Instance.getRedom(0, numList.Count)]);
                PolygonCollider2D collider = _Instance.GetComponent<PolygonCollider2D>();
                clearTimer();
                itemNum++;
            }

            yield return null;
        }
    }

    public void clearAllChildrenObject()
    {
        while (transform.childCount > 1)
        {
            GameObject childObject = transform.GetChild(1).gameObject;
            ObjectPool.Instance.pushInChildPool(childObject);
            ObjectPool.Instance.PushObject(childObject);
        }
        itemNum = 0;
    }

    public void addNumbers()
    {
        if (!isFever)
            StartCoroutine("brithNumbers");
    }
}
