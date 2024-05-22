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
        ballRb.velocity = initialVelocity.normalized * constantSpeed;
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
            ballRb.velocity = new Vector3(ballRb.velocity.x, -Mathf.Abs(ballRb.velocity.y), ballRb.velocity.z);
        }
        VelocityFix();
    }
    private void VelocityFix()
    {
        Vector3 velocity = ballRb.velocity;

        if (Mathf.Abs(velocity.x) < Mathf.Epsilon)
        {
            velocity.x = Random.Range(-1f, 1f) * constantSpeed;
        }
        if (Mathf.Abs(velocity.y) < Mathf.Epsilon)
        {
            velocity.y = Random.Range(-1f, 1f) * constantSpeed;
        }

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y) * 2)
        {
            velocity.y += Random.Range(0.5f, 1f) * Mathf.Sign(velocity.y == 0 ? 1 : velocity.y);
        }
        if (Mathf.Abs(velocity.y) > Mathf.Abs(velocity.x) * 2)
        {
            velocity.x += Random.Range(0.5f, 1f) * Mathf.Sign(velocity.x == 0 ? 1 : velocity.x);
        }

        ballRb.velocity = velocity.normalized * constantSpeed;
    }
}