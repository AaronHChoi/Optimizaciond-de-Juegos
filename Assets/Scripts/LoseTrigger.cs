using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BallArkanoid ball;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.LoseLife();
        playerController.ResetPosition();
        ball.ResetBall();
        GameManager.Instance.ResetScene();
    }
}
