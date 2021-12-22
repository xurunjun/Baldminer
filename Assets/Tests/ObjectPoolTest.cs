using System.Collections;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectPoolTest
{
    List<GameObject> gameObjects;

    [OneTimeSetUp]
    public void steup()
    {
        gameObjects = new List<GameObject>();

        gameObjects.Add(Resources.Load<GameObject>("Prefabs/Numbers/Number"));
        gameObjects.Add(Resources.Load<GameObject>("Prefabs/Bullets/addBullet"));
        gameObjects.Add(Resources.Load<GameObject>("Prefabs/Effect/Explose"));
    }

    [Test]
    public void ObjectPoolDirTest([NUnit.Framework.Range(1,3,1)] int size)
    {
        ObjectPool objectPool = new ObjectPool();

        for (int i = 0; i < size; i++)
        {
            objectPool.PushObject(gameObjects[i]);
        }

        int count = objectPool.getPoolSize();
        Assert.AreEqual(count,size);
        Debug.Log(count);
    }
    [Test]
    [Sequential]
    public void ObjectPoolQueueTest([Random(0,2,10)] int index,[Random(0,100,10)] int size)
    {
        ObjectPool objectPool = new ObjectPool();

        for(int i=0;i<size;i++)
        {
            objectPool.PushObject(gameObjects[index]);
        }

        int count = objectPool.getPoolQueueSize(gameObjects[index]);
        Assert.AreEqual(count,size);
        Debug.Log(count);


        for(int i=0;i<size;i++)
        {
            objectPool.GetObject(gameObjects[index]);
        }

        count = objectPool.getPoolQueueSize(gameObjects[index]);
        Assert.AreEqual(0,count);
        Debug.Log(count);

    }
}
