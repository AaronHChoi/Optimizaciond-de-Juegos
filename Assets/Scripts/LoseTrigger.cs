using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BallArkanoid ball;
    private void OnTriggerEnter(Collider other)
    {
        BallArkanoid ballComponent = other.GetComponent<BallArkanoid>();
        ballComponent.DestroyBall();
        if (GameManager.Instance.ballsInGame <= 0)
        {
            GameManager.Instance.LoseLife();
            playerController.ResetPosition();
            ball.ResetBall();
            GameManager.Instance.ResetScene();
        }
    }
}
