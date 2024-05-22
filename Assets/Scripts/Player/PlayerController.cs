using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _ballYDistance = 0.5f;
    private bool _ballIsMoving = false;

    public GameObject ball;

    private void Start()
    {
        BallStartPosition();
    }
    //private void Update()
    //{
    //    Move();
    //}

    public void CustomUpdate()
    {
        Move();
    }
    void Move()
    {
        float movement = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            movement = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            movement = 1f;

        Vector3 movementVector = new Vector3(movement, 0f, 0f) * _speed * Time.deltaTime;

        transform.Translate(movementVector);

        if (!_ballIsMoving)
            ball.transform.position = new Vector3(transform.position.x, transform.position.y + _ballYDistance, transform.position.z);
    }
    public void SetBallMoving(bool isMoving)
    {
        _ballIsMoving = isMoving;
    }
    void BallStartPosition()
    {
        float playerXPosition = transform.position.x;
        Vector3 ballPosition = new Vector3(playerXPosition, transform.position.y + _ballYDistance, 9.64f);
        ball.transform.position = ballPosition;
    }
}