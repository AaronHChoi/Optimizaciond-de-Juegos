using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour, IUpdatable
{
    [SerializeField] Brick multyBallBrick;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] BallManager ballManager;
    
    private Rigidbody multyballRb;
    
    void Start()
    {
        gameObject.SetActive(true);
        multyballRb = GetComponent<Rigidbody>();
        CustomUpdateManager.Instance.Register(this);
    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
            //ballSpawner.SpawnBall(2);
            ballManager.CreateBalls(2);
            gameObject.SetActive(false);
        }
    }
}