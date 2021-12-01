using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CollisionEvent:UnityEvent<Collision2D>{}
public class BulletSprite : MonoBehaviour
{
    public GameObject bullet;
    public CollisionEvent collisionEvent;

    public UnityAction<Collision2D> action;

    private bool hasBack=false;

    private void OnEnable() {
        hasBack=false;
    }

    private void OnBecameInvisible() {
        if(!hasBack)
        {
            Player.Instance.isFire=false;
            Player.Instance.isBack=false;
            GameManager.Instance.nextScoreEvent();
        }
        ObjectPool.Instance.PushObject(bullet);
        // Destroy(bullet);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        hasBack=true;
        Player.Instance.isFire=false;
        Player.Instance.isBack=true;
        collisionEvent.Invoke(other);
    }
}
