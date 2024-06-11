using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public ObjectPool ObjectPool;

    [SerializeField] int rows = 3;
    [SerializeField] int columns = 9;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector2 spacing;
    [SerializeField] Transform bricks;
    private void Awake()
    {
        if (ObjectPool.poolDictionary == null || ObjectPool.poolDictionary.Count == 0)
        {
            ObjectPool.InitializePool();
        }
    }
    public void CreateBricks(int bricksToCreate)
    {
        ClearBricks();
        int createdBricks = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (createdBricks >= bricksToCreate) { return; }
                GameObject brick = ObjectPool.GetPooledObject("Block");
                if (brick != null)
                {
                    brick.transform.position = new Vector3(startPosition.x + (col * spacing.x), startPosition.y - (row * spacing.y), startPosition.z);
                    brick.transform.SetParent(bricks);
                    brick.SetActive(true);
                    createdBricks++;
                }
            }
        }
    }
    public void ClearBricks()
    {
        foreach (Transform brick in bricks)
        {
            brick.gameObject.SetActive(false);
        }
    }
    public void ReturnBrick(GameObject brick)
    {
        if (ObjectPool != null)
        {
            Brick brickComponent = brick.GetComponent<Brick>();
            if (brickComponent != null)
                brickComponent.ResetBrick();
            ObjectPool.ReturnObjectToPool(brick, "Block");
        }
    }
}
