using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float bounds = 7f;
    private Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds); ;
        transform.position = playerPosition;
    }
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}