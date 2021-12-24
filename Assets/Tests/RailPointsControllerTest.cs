using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RailPointsControllerTest
{
    private RailPointsController controller;

    [OneTimeSetUp]
    public void setup()
    {
        controller = new RailPointsController();
        controller.getXY(-50, 50, -100, 100);
    }

    [Test]
    public void StartPhasePointsTest()
    {
        List<Vector2> points = new List<Vector2>();
        controller.amplitude = UnityEngine.Random.Range(0f, 100f);
        controller.frequency = UnityEngine.Random.Range(1.0f, 10.0f);
        controller.railCount = UnityEngine.Random.Range(1, 10);
        Debug.Log(
            "amplitude = " + controller.amplitude +
            "\nfrequency = " + controller.frequency +
            "\nrailCount = " + controller.railCount
        );

        Debug.Log(points.Count);

        controller.initStartPhasePoints(points);
        Debug.Log(points.Count);

        foreach (Vector2 point in points)
        {
            Debug.Log(point);
        }

        Debug.Log("End");
    }

    [Test]
    public void GetintAllPointsTest()
    {
        controller.amplitude = UnityEngine.Random.Range(0f, 100f);
        controller.frequency = UnityEngine.Random.Range(1.0f, 10.0f);
        controller.offset = UnityEngine.Random.Range(1f, 10f);
        controller.railCount = UnityEngine.Random.Range(1, 10);
        Debug.Log(
            "amplitude = " + controller.amplitude +
            "\nfrequency = " + controller.frequency +
            "\noffset = " + controller.offset +
            "\nrailCount = " + controller.railCount
        );
        List<List<Vector2>> points = controller.getAllPoints();
        Debug.Log(points.Count);

        foreach (List<Vector2> pointList in points)
        {
            Debug.Log(pointList.Count);
            foreach(Vector2 point in pointList)
            {
                Debug.Log(point);
            }
        }

        Debug.Log("End");
    }
}
