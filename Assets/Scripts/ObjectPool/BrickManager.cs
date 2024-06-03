using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public int rows = 5;
    public int columns = 10;
    public Vector2 startPosition;
    public Vector2 spacing;

    private void Start()
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
        CreateBricks();
    }
    void CreateBricks()
    {
        for (int row = 0; row < rows; row++)
        {
            for(int col = 0; col < columns; col++)
            {
                GameObject brick = objectPool.GetPooledObject("Block");
                if (brick != null)
                {
                    brick.transform.position = new Vector2(startPosition.x + (col * spacing.x), startPosition.y - (row * spacing.y));
                    brick.SetActive(true);
                }
                else
                {
                    Debug.LogError("Failed to get pooled object for Brick.");
                }
            }
        }
    }
    public void ReturnBrick(GameObject brick)
    {
        if (objectPool != null)
        {
            objectPool.ReturnObjectToPool(brick, "Block");
        }
    }
}
