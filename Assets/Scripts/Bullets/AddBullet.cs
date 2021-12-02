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
            other.rigidbody.AddForce(direction*speed*fourceFactor,ForceMode2D.Impulse);
            Player.Instance.isFire=false;
            Player.Instance.isBack=false;
            Destroy(gameObject);
        }
    }
}
