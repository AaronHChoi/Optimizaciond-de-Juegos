using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : MonoBehaviour
{
    public ObjectPool ObjectPool;

    protected virtual void Awake()
    {
        if (ObjectPool.poolDictionary == null || ObjectPool.poolDictionary.Count == 0)
        {
            ObjectPool.InitializePool();
        }
    }
    public abstract void CreateObjects(int objectsToCreate);
    public abstract void CreateObjects(Vector3 position);
    public virtual void ClearObjects<T>() where T : MonoBehaviour
    {
        T[] activeObjects = FindObjectsOfType<T>();
        foreach(T obj in activeObjects)
        {
            obj.gameObject.SetActive(false);
        }
    }
    public virtual void ReturnObject(GameObject obj, string tag)
    {
        if(ObjectPool != null)
        {
            ObjectPool.ReturnObjectToPool(obj, tag);
        }
    }
}