using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberSprite : MonoBehaviour
{
    public CollisionEvent collisionEvent;

    public UnityAction<Collision2D> action;

    private void OnCollisionEnter2D(Collision2D other) {
        collisionEvent.Invoke(other);
    }
}
