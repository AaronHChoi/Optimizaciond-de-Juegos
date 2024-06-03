using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public int rows = 3;
    public int columns = 9;
    public Vector3 startPosition;
    public Vector2 spacing;
    [SerializeField] private Transform bricks;

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
                    brick.transform.position = new Vector3(startPosition.x + (col * spacing.x), startPosition.y - (row * spacing.y), startPosition.z);
                    brick.transform.SetParent(bricks);
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
