using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public Vector3 startPosition;
    public Vector2 spacing;
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
        ClearBalls();
        int createdBalls = 0;
        if (createdBalls >= ballsToCreate) { return; }
        GameObject ball = objectPool.GetPooledObject("Ball");
        if (ball != null)
        {
            ball.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
            //transform.SetParent(player);
            
            ball.transform.SetParent(balls);
            
            ball.SetActive(true);
            createdBalls++;
        }
        else
        {
            Debug.LogError("Failed to get pooled object for Brick.");
        }
    }
    public void ClearBalls()
    {
        foreach (Transform ball in balls)
        {
            ball.gameObject.SetActive(false);
        }
    }
    public void ReturnBall(GameObject ball)
    {
        if (objectPool != null)
        {
            //BallArkanoid ballComponent = ball.GetComponent<BallArkanoid>();
            //if (ballComponent != null)
            //    ballComponent.ResetBall();
            objectPool.ReturnObjectToPool(ball, "Ball");
        }
    }
}
