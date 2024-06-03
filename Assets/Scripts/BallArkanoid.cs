using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour, IUpdatable
{
    [SerializeField] private Vector2 initialVelocity;

    [SerializeField] PlayerController playerController;
    private Rigidbody ballRb;
    [SerializeField] private BrickManager brickManager;
    private bool isBallMoving;
    private Vector3 initialPosition;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        //brickManager = GetComponent<BrickManager>();
        //playerController = GetComponent<PlayerController>();
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
    private void OnDisable() // para desregistrar la pelota del custom update manager de hacer falta.
    {
        CustomUpdateManager.Instance.Unregister(this);
    }
    private void LaunchBall()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
        isBallMoving = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.transform.parent?.GetComponent<Brick>();

        switch (collision.gameObject.tag)
        {
            case "BlockTop":
                UpdateVelocity(new Vector2(initialVelocity.x, 6));
                DestroyBlock(brick, collision);
                break;

            case "BlockBottom":
                UpdateVelocity(new Vector2(initialVelocity.x, -6));
                DestroyBlock(brick, collision);
                break;

            case "BlockRight":
                UpdateVelocity(new Vector2(4, initialVelocity.y > 0 ? 6 : -6));
                DestroyBlock(brick, collision);
                break;

            case "BlockLeft":
                UpdateVelocity(new Vector2(-4, initialVelocity.y > 0 ? 6 : -6));
                DestroyBlock(brick, collision);
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
                UpdateVelocity(new Vector2(0, 6));
                break;

            case "PlayerLeft":
                UpdateVelocity(new Vector2(-4, 6));
                break;

            case "PlayerRight":
                UpdateVelocity(new Vector2(4, 6));
                break;
        }
    }
    private void UpdateVelocity(Vector2 newVelocity)
    {
        initialVelocity = newVelocity;
        ballRb.velocity = initialVelocity;
    }
    private void DestroyBlock(Brick brick, Collision collision)
    {
        if(brick != null && !brick.isDestroyed)
        {
            brick.isDestroyed = true;
            //Destroy(collision.transform.parent.gameObject);
            brickManager.ReturnBrick(brick.gameObject);
            
            GameManager.Instance.BlockDestroyed();
            Debug.Log(GameManager.Instance.blockLeft);
            brick.ResetBrick();
        }
    }
    public void ResetBall()
    {
        ballRb.velocity = Vector3.zero;
        transform.position = initialPosition;
        transform.parent = playerController.transform;
        isBallMoving = false;
    }
}