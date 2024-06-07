using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public Vector3 startPosition;
    public Vector2 spacing;
    [SerializeField] int createdBalls = 0;
    [SerializeField] private Transform balls;
    [SerializeField] private Transform player;
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
    }
    public void CreateBalls(int ballsToCreate)
    {
        //ClearBalls();
        //int ballsNeeded = ballsToCreate - createdBalls;
        //if (createdBalls >= ballsToCreate) { return; }
        int initialCreatedBalls = createdBalls;
        for (int i = 0; i < ballsToCreate; i++)
        {
            GameObject ball = objectPool.GetPooledObject("Ball");
            if (ball != null)
            {
                if(ball.gameObject.activeInHierarchy == false)
                {
                    ball.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
                    ball.transform.SetParent(balls);
                    ball.SetActive(true);
                }
                createdBalls++;
            }
            else
            {
                Debug.LogError("Failed to get pooled object for Brick.");
            }
        }
        createdBalls = initialCreatedBalls + ballsToCreate;
    }
    public void ClearBalls()
    {
        foreach (Transform ball in balls)
        {
            ball.gameObject.SetActive(false);
        }
        createdBalls = 0;
    }
    public void ReturnBall(GameObject ball)
    {
        if (objectPool != null)
        {
            objectPool.ReturnObjectToPool(ball, "Ball");
        }
    }
}
