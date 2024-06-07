using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BallManager ballManager;
    private void OnTriggerEnter(Collider other)
    {
        BallArkanoid ballComponent = other.GetComponent<BallArkanoid>();
        ballComponent.DestroyBall();
        GameManager.Instance.ballsInGame--;
        if (GameManager.Instance.ballsInGame <= 0)
        {
            GameManager.Instance.LoseLife();
            playerController.ResetPosition();
            //ballComponent.ResetBall();
            ballManager.CreateBalls(1);
            GameManager.Instance.ResetScene();
        }
    }
}
