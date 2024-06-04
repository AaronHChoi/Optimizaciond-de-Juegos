using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MultyBall : MonoBehaviour, IUpdatable
{
    [SerializeField] Brick multyBallBrick;
    [SerializeField] BallSpawner ballSpawner;

    private Rigidbody multyballRb;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        multyballRb = GetComponent<Rigidbody>();
        CustomUpdateManager.Instance.Register(this);
    }

    // Update is called once per frame
    public void OnUpdate()
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
            ballSpawner.SpawnBall(2);
            gameObject.SetActive(false);
        }
    }
}
