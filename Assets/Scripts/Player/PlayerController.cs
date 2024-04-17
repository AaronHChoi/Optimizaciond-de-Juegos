using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad de la paleta
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        //Entrada del teclado
        float horizontalMovement = Input.GetAxis("Horizontal");
        //Calculo del movimiento
        Vector3 movement = new Vector3 (horizontalMovement, 0f, 0f) * _speed * Time.deltaTime;
        //Aplicar el movimiento
        transform.Translate(movement);
    }
}
