using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RailPointsController
{
    #region Field
    [Header("振幅")]
    public float amplitude;

    [Header("频率")]
    [Range(1f, 10f)]
    public float frequency = 1;

    [Header("相位偏移")]
    [Range(0f, 10f)]
    public float offset;

    [Header("轨道数量")]
    public int railCount;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private float maxHeight;
    #endregion

    public void getXY(float xMin, float xMax, float yMin, float yMax)
    {
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;
        this.yMax = yMax;
    }

    public void initStartPhasePoints(List<Vector2> points)
    {
        float grap = (xMax - xMin) / frequency;
        float xStart = xMin - grap;
        float xEnd = xMax + grap;

        maxHeight = (yMax - yMin) / railCount;
        float baseLine = yMin + maxHeight * (railCount - 0.5f);
        float height = amplitude > maxHeight / 2 ? maxHeight / 2 : amplitude;

        float xPoint = xStart;
        float yPoint = 0;

        if (((int)(Random.Range(0, 1) + 0.5)) == 1)
        {
            yPoint = baseLine + height;
        }
        else
        {
            yPoint = baseLine - height;
        }

        while (xPoint < xEnd)
        {
            points.Add(new Vector2(xPoint, yPoint));
            xPoint += grap;
            yPoint = yPoint > baseLine ? baseLine - height : baseLine + height;
        }
        points.Add(new Vector2(xPoint, yPoint));
    }

    public List<List<Vector2>> getAllPoints()
    {
        List<List<Vector2>> points = new List<List<Vector2>>();
        List<Vector2> startPoints = new List<Vector2>();
        initStartPhasePoints(startPoints);

        points.Add(startPoints);
        float grap = startPoints[1].x - startPoints[0].x;
        float distance = offset;

        for (int i = 1; i < railCount; i++)
        {
            List<Vector2> temp = new List<Vector2>();
            for (int j = 0; j < startPoints.Count; j++)
            {
                temp.Add(new Vector2(startPoints[j].x + distance, startPoints[j].y - maxHeight * i));
            }
            points.Add(temp);
            distance = distance + offset > grap ? distance + offset - grap : distance + offset;
        }

        return points;
    }
}
