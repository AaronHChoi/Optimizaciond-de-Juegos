using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdatable
{
    [SerializeField] private float moveSpeed;
    private float bounds = 6.1f;
    private Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
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
        //playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
        float newPositionX = playerPosition.x + moveInput * moveSpeed * Time.deltaTime;
        if(newPositionX < -bounds - 0.6f)
        {
            newPositionX = -bounds - 0.6f;
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
        transform.position = initialPosition;
    }
}