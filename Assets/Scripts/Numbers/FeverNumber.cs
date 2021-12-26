using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeverNumber : MonoBehaviour
{
    [Header("原材料")]
    public Material sourceMaterial;

    [Header("溶解材料")]
    public Material dissolveMaterial;

    [Header("Sprite")]
    public SpriteRenderer sprite;

    [Header("分数")]
    [Range(0, 10)]
    public int score;

    public UnityAction action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            // Debug.Log("On!");
            GameManager.Instance.addScoreInFever(score);
            action.Invoke();
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.tag == "bullet")
    //     {
    //         Debug.Log("On!");
    //         // GameManager.Instance.addScoreInFever(score);
    //         // action.Invoke();
    //     }
    // }

}
