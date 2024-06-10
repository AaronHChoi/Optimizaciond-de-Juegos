using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : MonoBehaviour
{
    public ObjectPool objectPool;

    protected virtual void Start()
    {
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool is not assigned.");
            return;
        }
        if (objectPool.poolDictionary == null || objectPool.poolDictionary.Count == 0)
        {
            objectPool.InitializePool();
        }
        if (objectPool.poolDictionary == null || objectPool.poolDictionary.Count == 0)
        {
            Debug.LogError("ObjectPool is not initialized.");
            return;
        }
    }
    public virtual void CreateObjects(Vector3 position)
    {

    }
    public virtual void ClearObjects()
    {

    }
    public virtual void ReturnObjects(GameObject obj, string tag)
    {
        obj.SetActive(false);
        if (objectPool.poolDictionary.ContainsKey(tag))
        {
            objectPool.poolDictionary[tag].Enqueue(obj);
        }
    }
}