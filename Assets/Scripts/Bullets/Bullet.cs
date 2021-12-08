using System.Collections;
using UnityEngine;
using UnityEngine.UI;

abstract public class Bullet : MonoBehaviour
{
    [Header("速度")]
    public float speed;
    [Header("方向")]
    public Vector2 direction;
    [Header("旋转速度因子")]
    public float rotateSpeedFactor;
    [Header("力量因子")]
    public float fourceFactor;
    [Header("发射中")]
    public bool isFlying=false;
    [Header("当前位置")]
    public Vector2 currentPos;
    [Header("刚体")]
    public new Rigidbody2D rigidbody;
    [Header("爆炸效果")]
    public GameObject explose;

    private void OnEnable() {
        isFlying=false;
    }

    public virtual void startFly(float velocity,Vector2 direction,float size)
    {
        this.speed=velocity;
        this.direction=direction;
        this.transform.localScale=Vector3.one*size;
        isFlying=true;
        StartCoroutine("fly");
    }
    abstract public IEnumerator fly();
}
