using System.Collections;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectPoolTest
{

    [Test]
    public void ObjectPoolDirTest()
    {
        ObjectPool objectPool = ObjectPool.Instance;


        GameObject gameObject = Resources.Load<GameObject>("Prefabs/Numbers/Number");

        objectPool.PushObject(gameObject);

        Assert.AreEqual(1,objectPool.getPoolSize());
    }
    [Test]
    public void ObjectPoolQueueTest()
    {
        ObjectPool objectPool = ObjectPool.Instance;


        GameObject gameObject = Resources.Load<GameObject>("Prefabs/Numbers/Number");

        objectPool.PushObject(gameObject);

        Assert.AreEqual(1,objectPool.getPoolQueueSize(gameObject));

        GameObject pullObject = objectPool.GetObject(gameObject);

        Assert.AreEqual(0,objectPool.getPoolQueueSize(gameObject));
    }
}
