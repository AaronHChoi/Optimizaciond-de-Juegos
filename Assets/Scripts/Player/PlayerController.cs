using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad de la paleta
    [SerializeField] private float _speed = 5f;

    private void Update()
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
    }
}
