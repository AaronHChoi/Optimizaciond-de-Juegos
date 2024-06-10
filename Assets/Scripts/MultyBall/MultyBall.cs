using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour, IUpdatable
{
    BallManager ballManager;
    MultyBallManager multyBallManager;
    Rigidbody multyballRb;
    private Vector2 fall;

    void Start()
    {
        fall.y = -4f;
        gameObject.SetActive(true);
        ballManager = FindObjectOfType<BallManager>();
        multyBallManager = FindObjectOfType<MultyBallManager>();
        multyballRb = GetComponent<Rigidbody>();
        CustomUpdateManager.Instance.Register(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerLeft" || collision.gameObject.tag == "PlayerRight")
        {
            ballManager.CreateBalls(1);
            //gameObject.SetActive(false);
            multyBallManager.ReturnObjects(this.gameObject);
        } else if (collision.gameObject.tag == "Dead")
        {
            multyBallManager.ReturnObjects(this.gameObject);
        }
    }
    public void DestroyMultyBall()
    {
        multyBallManager.ReturnObjects(this.gameObject);
    }

    public void OnUpdate()
    {
        multyballRb.velocity = fall;
    }
}