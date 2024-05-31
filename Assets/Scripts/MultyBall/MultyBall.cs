using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour
{
    [SerializeField] Brick multyBallBrick;
    [SerializeField] BallArkanoid ball_1;
    [SerializeField] BallArkanoid ball_2;

    private Rigidbody multyballRb;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        multyballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void CustomUpdate()
    {
        if (multyBallBrick.isDestroyed == true)
        {
            LaunchMultyBallPowerUp();
        }
    }

    public void LaunchMultyBallPowerUp()
    {
        multyballRb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //logica de spawn dos bolas mas 
            gameObject.SetActive(false);
            ball_1.gameObject.SetActive(true);
            ball_2.gameObject.SetActive(true);
        }
    }
}
