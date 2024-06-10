using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallArkanoid : MonoBehaviour, IUpdatable
{
    public Vector2 initialVelocity;

    Rigidbody ballRb;
    bool isBallMoving;
    Vector3 initialPosition;

    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        CustomUpdateManager.Instance.Register(this);
    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            LaunchBall();
        }
    }
    private void LaunchBall()
    {
        transform.parent = null;
        ballRb.velocity = GetRandomVelocity(new Vector2(0, 6));
        isBallMoving = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.transform.GetComponentInParent<Brick>();
        
        switch (collision.gameObject.tag)
        {
            case "BlockRight":
                UpdateVelocity(new Vector2(4, initialVelocity.y > 0 ? 6 : -6));
                brick.DestroyBlock();
                break;

            case "BlockLeft":
                UpdateVelocity(new Vector2(-4, initialVelocity.y > 0 ? 6 : -6));
                brick.DestroyBlock();
                break;

            case "BlockTop":
                UpdateVelocity(new Vector2(initialVelocity.x, 6));
                brick.DestroyBlock();
                break;

            case "BlockBottom":
                UpdateVelocity(new Vector2(initialVelocity.x, -6));
                brick.DestroyBlock();
                break;

            case "Top":
                UpdateVelocity(new Vector2(initialVelocity.x, -6));
                break;

            case "Right":
                UpdateVelocity(new Vector2(-4, initialVelocity.y > 0 ? 6 : -6));
                break;

            case "Left":
                UpdateVelocity(new Vector2(4, initialVelocity.y > 0 ? 6 : -6));
                break;

            case "Player":
                UpdateVelocity(GetRandomVelocity(new Vector2(0, 6)));
                break;

            case "PlayerLeft":
                UpdateVelocity(GetRandomVelocity(new Vector2(-4, 6)));
                break;

            case "PlayerRight":
                UpdateVelocity(GetRandomVelocity(new Vector2(4, 6)));
                break;
            case "Dead":
                DestroyBall();
                GameManager.Instance.loseTrigger.Lose();
                break;
        }
    }
    public void UpdateVelocity(Vector2 newVelocity)
    {
        initialVelocity = newVelocity;
        ballRb.velocity = initialVelocity;
    }
    public void ResetBall()
    {
        //ballManager.CreateBalls(1);
        ballRb.velocity = Vector3.zero;
        transform.position = initialPosition;
        transform.parent = GameManager.Instance.playerController.transform;
        isBallMoving = false;
    }
    private Vector2 GetRandomVelocity(Vector2 baseVelocity)
    {
        float variationX = Random.Range(-2f, 2f);
        baseVelocity.x += variationX;
        //return new Vector2(baseVelocity.x + variationX, baseVelocity.y);
        return baseVelocity;
    }
    public void DestroyBall()
    {
        GameManager.Instance.ballManager.ReturnBall(this.gameObject);
    }
}