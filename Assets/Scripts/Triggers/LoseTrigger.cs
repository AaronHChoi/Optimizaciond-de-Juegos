using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public void Lose()
    {
        GameManager.Instance.ballsInGame--;
        if (GameManager.Instance.ballsInGame <= 0)
        {
            GameManager.Instance.LoseLife();
            GameManager.Instance.playerController.ResetPosition();
            GameManager.Instance.ballManager.CreateBalls(1);
            GameManager.Instance.ResetScene();
        }
    }
}
