using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public void Lose()
    {
        var gameManager = GameManager.Instance;

        gameManager.ballsInGame--;

        if (gameManager.ballsInGame <= 0)
        {
            gameManager.LoseLife();
            gameManager.playerController.ResetPosition();
            gameManager.ballManager.CreateBalls(1);
            gameManager.ResetScene();
        }
    }
}
