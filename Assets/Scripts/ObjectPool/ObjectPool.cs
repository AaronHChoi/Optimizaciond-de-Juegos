using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    [SerializeField] Brick brick;
    public void InitializePool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject GetPooledObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();

        if (obj == null)
        {
            Debug.LogWarning("Object with tag " + tag + " is null.");
            return null;
        }

        poolDictionary[tag].Enqueue(obj);
        return obj;
    }
    public void ReturnObjectToPool(GameObject obj, string tag)
    {
        obj.SetActive(false);
        if (poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag].Enqueue(obj);
        }
        else
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
        }
    }
}
