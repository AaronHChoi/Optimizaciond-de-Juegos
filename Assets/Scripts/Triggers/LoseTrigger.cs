using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public AudioClip LoseSFX;
    public void Lose()
    {
        var gameManager = GameManager.Instance;

        gameManager.BallsInGame--;

        if (gameManager.BallsInGame <= 0)
        {
            AudioManager.Instance.PlaySFX(LoseSFX);
            gameManager.LoseLife();
            gameManager.playerController.ResetPosition();
            gameManager.ballManager.CreateObjects(1);
            gameManager.ResetScene();
        }
    }
}
