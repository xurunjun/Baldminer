using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{

    private RectTransform rect;

    [SerializeField]
    private List<List<Vector2>> railPoints;

    private List<RailCar> Cars;

    public RailPointsController pointsController;

    [Header("预制体")]
    public GameObject Number;

    [Header("速度")]
    public float velocity;

    [Header("生成间隔")]
    [Range(0f, 1f)]
    public float time;

    public bool isStop = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        Cars = new List<RailCar>();
        pointsController.getXY(
            rect.rect.xMin, rect.rect.xMax,
            rect.rect.yMin + rect.transform.position.y, rect.rect.yMax + rect.transform.position.y
        );
        railPoints = pointsController.getAllPoints();
    }

    private void OnDisable()
    {
        stop();
    }

    public async void startToBrith()
    {
        while (!isStop)
        {
            RailCar car = new RailCar(
                ObjectPool.Instance.GetObject(Number),
                (RailCar.DIRECTION)getDirection(),
                railPoints[GameManager.Instance.getRedom(0, railPoints.Count)],
                velocity
            );
            car.setStopAction(() =>
            {
                Cars.Remove(car);
            });
            Cars.Add(car);

            car.go();
            await Task.Delay((int)(time * 1000));
        }
    }

    private int getDirection()
    {
        return ((int)(GameManager.Instance.getRedom(0f, 1f) + 0.5));
    }

    internal void stop()
    {
        foreach (RailCar car in Cars)
        {
            car.stop();
        }
        isStop = true;
    }
}
