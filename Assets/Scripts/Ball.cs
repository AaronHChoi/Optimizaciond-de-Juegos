using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;
    float _forceMagnitude = 600f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //_rb.AddForce(Vector3.up * _forceMagnitude * Time.deltaTime);
    }
}
