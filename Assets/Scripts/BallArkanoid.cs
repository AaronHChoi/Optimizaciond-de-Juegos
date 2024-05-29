using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float constantSpeed = 7.0f;

    private Rigidbody ballRb;
    private bool isBallMoving;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            LaunchBall();
        }
    }
    private void LaunchBall()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
        isBallMoving = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.BlockDestroyed();
        }
        if (collision.gameObject.CompareTag("Top"))
        {
            if(initialVelocity.x < 0) // si la pelota viene de derecha y abajo
            {
                initialVelocity.x = -4;
                initialVelocity.y = -6;
                ballRb.velocity = initialVelocity;
            }
            if (initialVelocity.x > 0) // si la pelota viene de izquierda y abajo
            {
                initialVelocity.x = 4;
                initialVelocity.y = -6;
                ballRb.velocity = initialVelocity;
            }
            if (initialVelocity.x == 0) // si la pelota viene de izquierda y abajo
            {
                initialVelocity.x = 0;
                initialVelocity.y = -6;
                ballRb.velocity = initialVelocity;
            }
        }
        if (collision.gameObject.CompareTag("Right"))
        {
            if(initialVelocity.y > 0) // de abajo para arriba
            {
                initialVelocity.x = -4;
                initialVelocity.y = 6;
                ballRb.velocity = initialVelocity;
            }
            if (initialVelocity.y < 0) // de arriba para abajo
            {
                initialVelocity.x = -4;
                initialVelocity.y = -6;
                ballRb.velocity = initialVelocity;
            }
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            if (initialVelocity.y > 0) // de abajo para arriba
            {
                initialVelocity.x = 4;
                initialVelocity.y = 6;
                ballRb.velocity = initialVelocity;
            }
            if (initialVelocity.y < 0) // de arriba para abajo
            {
                initialVelocity.x = 4;
                initialVelocity.y = -6;
                ballRb.velocity = initialVelocity;
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            initialVelocity.x = 0;
            initialVelocity.y = 6;
            ballRb.velocity = initialVelocity;
        }
        if (collision.gameObject.CompareTag("PlayerLeft"))
        {
            initialVelocity.x = -4;
            initialVelocity.y = 6;
            ballRb.velocity = initialVelocity;
        }
        if (collision.gameObject.CompareTag("PlayerRight"))
        {
            initialVelocity.x = 4;
            initialVelocity.y = 6;
            ballRb.velocity = initialVelocity;
        }
    }
}