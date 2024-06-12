using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : ObjectManager
{
    Vector3 startPosition = new Vector3(-142f, 40.75f, -29.862f); 
    [SerializeField] Transform balls;

    public override void CreateObjects(int ballsToCreate)
    {
        for (int i = 0; i < ballsToCreate; i++)
        {
            GameObject ball = ObjectPool.GetPooledObject("Ball");
            if (ball != null && !ball.activeInHierarchy)
            {
                ball.transform.position = startPosition;
                ball.transform.SetParent(balls, false);
                ball.SetActive(true);

                GameManager.Instance.BallsInGame++;
            }
        }
    }
    public void ClearBalls()
    {
        ClearObjects<BallArkanoid>();
    }
    public void ReturnBall(GameObject ball)
    {
        ReturnObject(ball, "Ball");
    }
    public override void CreateObjects(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}