using System;
using UnityEngine;
using UnityEngine.Events;

//如需要参数则继承内置UnityEvent<T>
[Serializable]
public class CollisionEvent:UnityEvent<Collision2D>{}
public class BulletSprite : MonoBehaviour
{
    public GameObject bullet;

    //定义实例化事件
    public CollisionEvent collisionEvent;

    private bool hasBack=false;

    private void OnEnable() {
        hasBack=false;
    }

    private void OnBecameInvisible() {
        bullet.GetComponent<AddBullet>().StopAllCoroutines();
        if(!hasBack)
        {
            Player.Instance.isFire=false;
            Player.Instance.isBack=false;
            GameManager.Instance.nextScoreEvent();
        }
        ObjectPool.Instance.PushObject(bullet);
        // Destroy(bullet);
    }

    //碰撞函数
    private void OnCollisionEnter2D(Collision2D other) {
        hasBack=true;
        Player.Instance.isFire=false;
        Player.Instance.isBack=true;
        //碰撞时触发
        collisionEvent.Invoke(other);
    }
}
