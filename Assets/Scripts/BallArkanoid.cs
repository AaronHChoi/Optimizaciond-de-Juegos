using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallArkanoid : MonoBehaviour, IUpdatable
{
    public Vector2 initialVelocity;

    PlayerController playerController;
    Rigidbody ballRb;
    BallManager ballManager;
    private bool isBallMoving;
    private Vector3 initialPosition;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        ballManager = GetComponentInParent<BallManager>();
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
        Brick brick = collision.transform.GetComponent<Brick>();
        //if (brick != null && !brick.isDestroyed)
        //{
        //    SideDetection sideDetection = brick.GetComponent<SideDetection>();
        //    if(sideDetection != null )
        //    {
        //        Vector3 hitPoint = collision.GetContact(0).point;
        //        string hitSide = sideDetection.GetHitSide(hitPoint);
        //        Debug.Log(hitSide);
        //        switch (hitSide)
        //        {
        //            case "BlockRight":
        //                UpdateVelocity(new Vector2(4, initialVelocity.y > 0 ? 6 : -6));
        //                break;
        //            case "BlockLeft":
        //                UpdateVelocity(new Vector2(-4, initialVelocity.y > 0 ? 6 : -6));
        //                break;
        //            case "BlockTop":
        //                UpdateVelocity(new Vector2(initialVelocity.x, 6));
        //                break;
        //            case "BlockBottom":
        //                UpdateVelocity(new Vector2(initialVelocity.x, -6));
        //                break;
        //        }
        //        brick.DestroyBlock();
        //    }
        //}
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
        transform.parent = playerController.transform;
        isBallMoving = false;
    }
    private Vector2 GetRandomVelocity(Vector2 baseVelocity)
    {
        float variationX = Random.Range(-2f, 2f);
        return new Vector2(baseVelocity.x + variationX, baseVelocity.y);
    }
    public void DestroyBall()
    {
        ballManager.ReturnBall(this.gameObject);
    }
}