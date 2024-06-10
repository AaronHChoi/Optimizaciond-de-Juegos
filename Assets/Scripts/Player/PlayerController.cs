using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdatable
{
    float moveSpeed = 10;
    float bounds = 6.1f;
    float extraBound = 0.6f;
    Vector3 initialPosition;
    Transform playerTransform;
    private void Start()
    {
        playerTransform = transform;
        initialPosition = playerTransform.position;
        CustomUpdateManager.Instance.Register(this);
    }
    public void OnUpdate()
    {
        Move();
    }
    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 playerPosition = transform.position;
        float newPositionX = playerPosition.x + moveInput * moveSpeed * Time.deltaTime;

        if(newPositionX < -bounds - extraBound)
        {
            newPositionX = -bounds - extraBound;
        }
        else if(newPositionX > bounds)
        {
            newPositionX = bounds;
        }

        playerPosition.x = newPositionX; 
        transform.position = playerPosition;
    }
    public void ResetPosition()
    {
        playerTransform.position = initialPosition;
    }
}