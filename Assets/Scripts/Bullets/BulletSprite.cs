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

    private void OnBecameInvisible() {
        Player.Instance.isFire=false;
        Player.Instance.isBack=false;
        Destroy(bullet);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collisionEvent.Invoke(other);
    }
}
