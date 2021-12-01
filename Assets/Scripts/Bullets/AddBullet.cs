using UnityEngine;

public class AddBullet : Bullet
{
    public override void fly()
    {
        transform.position =  currentPos+direction*speed;
        rigidbody.transform.Rotate(Vector3.forward*speed*rotateSpeedFactor);
    }
    
    public void OnCollisionAction(Collision2D other) {
        if(other.gameObject.tag=="Number")
        {
            GameObject e =  Instantiate(explose);
            e.transform.position = transform.position;
            ObjectPool.Instance.PushObject(gameObject);
            // Destroy(gameObject);
        }
    }
}
