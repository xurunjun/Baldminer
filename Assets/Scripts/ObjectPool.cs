using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class ObjectPool
{
    private static ObjectPool _instance;

    private Dictionary<string,Queue<GameObject>> pooldic = new Dictionary<string, Queue<GameObject>>();

    private GameObject pool;

    public static ObjectPool Instance{
        get{
            if(_instance==null)
            {
                _instance = new ObjectPool();
            }
            return _instance;
        }
    }

    public int getPoolQueueSize(GameObject prefab)
    {
        if(pooldic.ContainsKey(prefab.name))
            return pooldic[prefab.name].Count;
    
        return 0;
    }

    public int getPoolSize()
    {
        return pooldic.Count;
    }

    public GameObject GetObject(GameObject prefab){
        GameObject _object;
        if(!pooldic.ContainsKey(prefab.name)||pooldic[prefab.name].Count==0)
        {
            _object = GameObject.Instantiate(prefab);
            PushObject(_object);
            if(pool==null)
            {
                pool = new GameObject("ObjectPool");
            }
            GameObject childPool = GameObject.Find(prefab.name+"Pool");
            if(!childPool)
            {
                childPool = new GameObject(prefab.name+"Pool");
                childPool.transform.SetParent(pool.transform);
            }
            _object.transform.SetParent(childPool.transform);
        }
        _object = pooldic[prefab.name].Dequeue();
        _object.SetActive(true);
        return _object;
    }

    public void PushObject(GameObject prefab)
    {
        string _name = prefab.name.Replace("(Clone)",string.Empty);
        if(!pooldic.ContainsKey(_name))
        {
            pooldic.Add(_name,new Queue<GameObject>());
        }
        pooldic[_name].Enqueue(prefab);
        prefab.SetActive(false);
    }
}
