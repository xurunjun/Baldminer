using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Laser
{
    #region Field
    [Header("起始位置")]
    public Vector2 startPosition;
    private GameObject shotingLight;
    [Header("激光列表")]
    public GameObject light;
    private GameObject effect;
    [Header("蓄力特效")]
    public GameObject accumulateEffect;

    private GameObject finishEffect;
    [Header("蓄满特效")]
    public GameObject FinishEffect;
    public bool hasStart;

    public bool hasFinish;
    public bool isShooting;

    public bool hasCancel;
    [Header("最大持续时间")]
    public float maxTime = 3;

    public float finishTime = 1;
    [Header("最大宽度")]
    public int LineWidth = 25;
    [Header("每秒生成粒子数量")]
    public int rateTime;
    #endregion

    public Laser()
    {
        hasStart = hasFinish = false;
        hasCancel = true;
    }

    public void startAccumulate()
    {
        if (hasCancel)
        {
            hasCancel = false;
            hasStart = true;
            effect = ObjectPool.Instance.GetObject(accumulateEffect);
            effect.transform.position = startPosition;
        }
    }

    private void clearEffect()
    {
        ParticleSystem.EmissionModule emission = effect.GetComponent<ParticleSystem>().emission;
        emission.rateOverTime = rateTime;
        ObjectPool.Instance.PushObject(effect);
        effect = null;
    }

    public void finishAccumulate()
    {
        if (hasStart && !hasFinish)
        {
            hasFinish = true;
            ParticleSystem.EmissionModule emission = effect.GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = 0;
            startFinishEffect();
        }
    }

    private async void startFinishEffect()
    {
        await Task.Delay(4 * 100);
        finishEffect = ObjectPool.Instance.GetObject(FinishEffect);
        finishEffect.transform.position = startPosition;
    }

    private void clearFinishEffect()
    {
        ObjectPool.Instance.PushObject(finishEffect);
        finishEffect = null;
    }

    #region lightShot
    private Quaternion getRadius(Vector2 direction)
    {
        return Quaternion.FromToRotation(Vector3.down, direction);
    }

    public void shotLaser(Vector2 direction, float duration)
    {
        if (hasStart && !isShooting)
        {
            isShooting = true;
            clearEffect();
            float factor = duration / finishTime;
            if (hasFinish)
            {
                factor = 1;
                clearFinishEffect();
            }
            if (factor > 0.2f)
            {
                shotingLight = ObjectPool.Instance.GetObject(light);
                shotingLight.transform.position = startPosition;
                shotingLight.transform.rotation = getRadius(direction);
                shotingLight.GetComponentInChildren<LineRenderer>().widthMultiplier = factor * LineWidth;
                shotingLight.transform.localScale = new Vector3(factor, 1, 1);
                shotingLight.GetComponentInChildren<BoxCollider2D>().enabled = true;
                Shotting(factor * maxTime);
            }
            else
            {
                hasStart = false;
                hasFinish = false;
                isShooting = false;
                hasCancel = true;
            }
        }
    }

    private async void Shotting(float duration)
    {
        await Task.Delay((int)(duration * 1000));
        shotingLight.GetComponentInChildren<BoxCollider2D>().enabled = false;
        shotingLight.GetComponentInChildren<LineRenderer>().widthMultiplier = LineWidth;
        shotingLight.transform.localScale = Vector3.one;
        ObjectPool.Instance.PushObject(shotingLight);
        shotingLight = null;
        hasStart = false;
        hasFinish = false;
        isShooting = false;
        hasCancel = true;
        Player.Instance.isLaser = false;
    }
    #endregion
}
