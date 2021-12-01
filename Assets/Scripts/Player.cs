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
    [Header("基础速度")]
    public float speed;
    private Vector2 direction;
    public bool isFire;
    public bool isBack;

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
            bullet = Instantiate(bulletList[GameManager.Instance.getRedom(0,bulletList.Count)]);
            bullet.transform.position = startPosition;
            bullet.GetComponent<AddBullet>().startFly(speed,direction);
            isFire=true;
        }
    }
}
