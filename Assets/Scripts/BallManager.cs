using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public Vector3 startPosition;
    [SerializeField] int createdBalls = 0;
    [SerializeField] private Transform balls;
    [SerializeField] private Transform player;
    private void Start()
    {
        startPosition.x = -142f;//-0.05f;//-0.02f;
        startPosition.y = 40.75f;//0.48f;//-6.904f;
        startPosition.z = -29.862f;//0.18f;//9.78f;
        
        if (objectPool.poolDictionary == null || objectPool.poolDictionary.Count == 0)
        {
            objectPool.InitializePool();
        }
    }
    public void CreateBalls(int ballsToCreate)
    {
        int initialCreatedBalls = createdBalls;
        for (int i = 0; i < ballsToCreate; i++)
        {
            GameObject ball = objectPool.GetPooledObject("Ball");
            if (ball != null)
            {
                if (!ball.gameObject.activeInHierarchy)
                {
                    //ball.transform.localPosition = Vector3.zero;
                    ball.transform.position = startPosition;
                    ball.transform.SetParent(balls, false);
                    ball.SetActive(true);

                    GameManager.Instance.ballsInGame++;
                    createdBalls++;
                }
            }
        }
        createdBalls = initialCreatedBalls + ballsToCreate;
    }
    public void ClearBalls()
    {
        BallArkanoid[] activeBalls = FindObjectsOfType<BallArkanoid>();
        foreach (BallArkanoid ball in activeBalls)
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