using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    [Header("回收中")]
    public bool isBacking;
    [Header("转向速度")]
    public float lerp;
    [Header("回收速度")]
    public float speed;
    [Header("目标位置")]
    public Vector2 targetPos;
    [Header("目标方向")]
    public Vector2 direction;
    [Header("旋转速度")]
    public float roationSpeed;
    [Header("物体基本大小")]
    public float baseScale;
    [Header("物体分数")]
    public int score;
    [Header("密度")]
    public float density;
    [Header("刚体")]
    public new Rigidbody2D rigidbody;
    [Header("动画状态机")]
    public Animator animator;
    private void OnEnable() {
        isBacking=false;
        rigidbody.interpolation=RigidbodyInterpolation2D.Interpolate;
        rigidbody.isKinematic=false;
        rigidbody.velocity=Vector2.zero;
        rigidbody.angularVelocity=0;
    }

    public void setScore(int factor)
    {
        this.score=factor;
        transform.localScale=new Vector3(baseScale/factor,baseScale/factor,1);
    }

    private void FixedUpdate() {
        direction=(targetPos-(Vector2)transform.position).normalized;

        if(isBacking)
        {
            // rigidbody.transform.Rotate(Vector3.forward*roationSpeed);
            transform.right=Vector3.Slerp(transform.right,direction,lerp/Vector2.Distance(transform.position,targetPos));
            rigidbody.velocity=transform.right*speed;
        }
        if(Vector2.Distance(transform.position,targetPos)<2f&&isBacking)
        {
            isBacking=false;
            animator.SetBool("isbacking",false);
            recycleComplete();
        }
    }

    public void recycleComplete()
    {
        rigidbody.velocity=Vector2.zero;
        transform.position=targetPos;
        StartCoroutine(waitToDestory(gameObject,.8f));
    }

    IEnumerator waitToDestory(GameObject gameObject,float time)
    {
        yield return new WaitForSeconds(time);
        Player.Instance.isBack=false;
        GameManager.Instance.changeScore(score);
        GenerateManager.Instance.itemNum--;
        ObjectPool.Instance.PushObject(gameObject);
        if(gameObject.activeInHierarchy)
        {
            ObjectPool.Instance.PushObject(gameObject);
        }
        // Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="bullet")
        {
            isBacking=true;
            animator.SetBool("isbacking",true);
            rigidbody.interpolation=RigidbodyInterpolation2D.None;
            rigidbody.isKinematic=true;
        }
    }
}
