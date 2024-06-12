using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}
public class ObjectPool : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
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
        if (!poolDictionary.ContainsKey(tag) && poolDictionary[tag].Count == 0)
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();

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
    }
}
