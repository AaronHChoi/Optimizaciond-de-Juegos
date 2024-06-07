using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour
{
    BallManager ballManager;
    Rigidbody multyballRb;
    
    void Start()
    {
        gameObject.SetActive(true);
        ballManager = FindObjectOfType<BallManager>();
        multyballRb = GetComponent<Rigidbody>();
        multyballRb.useGravity = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerLeft" || collision.gameObject.tag == "PlayerRight")
        {
            ballManager.CreateBalls(2);
            gameObject.SetActive(false);
        }
    }
}