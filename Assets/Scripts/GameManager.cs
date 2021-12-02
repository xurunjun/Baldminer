using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : Singleton<GameManager>
{
    [Header("随机种子")]
    public int seed;
    // Start is called before the first frame update
    private void Awake() {
        Random.InitState(seed);
    }

    public int  getRedom(int minValue,int maxValue)
    {
        return Random.Range(minValue,maxValue);
    }
}
