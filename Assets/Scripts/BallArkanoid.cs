using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    [SerializeField] private float _ballSpeed = 5f;
    private Vector3 _direction = Vector3.zero;

    public PlayerController _playerController;
    public GameObject _topEdge;
    public GameObject _rightEdge;
    public GameObject _leftEdge;
    private void Start()
    {
        _direction = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _ballSpeed * Time.deltaTime);

        DetectCollision();

        BallLaunch();
    }

    private void DetectCollision()
    {
        if(transform.position.y <= _playerController.transform.position.y +0.4f)
            _direction.y *= -1;
        if (transform.position.y >= _topEdge.transform.position.y - 0.4f)
            _direction.y *= -1;
        if (transform.position.x >= _rightEdge.transform.position.x -0.4f || transform.position.x <= _leftEdge.transform.position.x + 0.4f)
            _direction.x *= -1;
    }

    private void BallLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerController.SetBallMoving(true);
            _direction = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized;
        } 
    }
}