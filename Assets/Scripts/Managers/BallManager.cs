using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObjectPool ObjectPool;

    Vector3 startPosition = new Vector3(-142f, 40.75f, -29.862f); 
    [SerializeField] Transform balls;

    private void Start()
    {
        if (ObjectPool.poolDictionary == null || ObjectPool.poolDictionary.Count == 0)
        {
            ObjectPool.InitializePool();
        }
    }
    public void CreateBalls(int ballsToCreate)
    {
        for (int i = 0; i < ballsToCreate; i++)
        {
            GameObject ball = ObjectPool.GetPooledObject("Ball");
            if (ball != null && !ball.activeInHierarchy)
            {
                ball.transform.position = startPosition;
                ball.transform.SetParent(balls, false);
                ball.SetActive(true);

                GameManager.Instance.ballsInGame++;
            }
        }
    }
    public void ClearBalls()
    {
        BallArkanoid[] activeBalls = FindObjectsOfType<BallArkanoid>();
        foreach (BallArkanoid ball in activeBalls)
        {
            ball.gameObject.SetActive(false);
        }
    }
    public void ReturnBall(GameObject ball)
    {
        if (ObjectPool != null)
        {
            ObjectPool.ReturnObjectToPool(ball, "Ball");
        }
    }
}