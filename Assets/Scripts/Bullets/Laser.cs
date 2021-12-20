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
        }
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
            }
            if (factor > 0.2f)
            {
                shotingLight = ObjectPool.Instance.GetObject(light);
                shotingLight.transform.position = startPosition;
                shotingLight.transform.rotation = getRadius(direction);
                shotingLight.GetComponentInChildren<LineRenderer>().widthMultiplier = factor * LineWidth;
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
        shotingLight.GetComponentInChildren<LineRenderer>().widthMultiplier = LineWidth;
        ObjectPool.Instance.PushObject(shotingLight);
        shotingLight = null;
        hasStart = false;
        hasFinish = false;
        isShooting = false;
        hasCancel = true;
    }
    #endregion
}
