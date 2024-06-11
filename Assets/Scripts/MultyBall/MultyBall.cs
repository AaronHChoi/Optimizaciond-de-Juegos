using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour, IUpdatable
{
    public AudioClip MultyBallSFX;
    Rigidbody multyballRb;
    private Vector2 fall;

    void Start()
    {
        fall.y = -4f;
        multyballRb = GetComponent<Rigidbody>();
        CustomUpdateManager.Instance.Register(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var gameManager = GameManager.Instance;
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerLeft" || collision.gameObject.tag == "PlayerRight")
        {
            AudioManager.Instance.PlaySFX(MultyBallSFX);
            gameManager.ballManager.CreateBalls(1);
            gameManager.multyBallManager.ReturnObjects(this.gameObject);
            gameManager.PowerActive = false;
        } else if (collision.gameObject.tag == "Dead")
        {
            gameManager.multyBallManager.ReturnObjects(this.gameObject);
            gameManager.PowerActive = false;
        }
    }
    public void DestroyMultyBall()
    {
        GameManager.Instance.multyBallManager.ReturnObjects(this.gameObject);
    }

    public void OnUpdate()
    {
        multyballRb.velocity = fall;
    }
}