using System.Collections;
using UnityEngine;

public class AddBullet : Bullet
{
    public override IEnumerator fly()
    {
        while (true)
        {
            currentPos = transform.position;
            transform.position = currentPos + direction * speed;
            rigidbody.transform.Rotate(Vector3.forward * speed * rotateSpeedFactor);
            yield return null;
        }
    }

    public void OnCollisionAction(Collision2D other)
    {
        if (other.gameObject.tag == "Number")
        {
            StopAllCoroutines();
            GameObject e = Instantiate(explose);
            e.transform.position = transform.position;
            ObjectPool.Instance.PushObject(gameObject);
            // Destroy(gameObject);
        }
    }
}
