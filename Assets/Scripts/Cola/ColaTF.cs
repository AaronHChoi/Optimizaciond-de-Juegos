using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaTF : ColaTDA
{
    //creo la Queue de las pelotas
    public Queue BallQueue => _ballQueue;
    private Queue _ballQueue = new Queue();

    int _indice;
    public void Acolar(GameObject GameObject)//Agrega pelotas a la Queue
    {
        _ballQueue.Enqueue(GameObject);
        _indice++;
    }
    public void Desacolar(GameObject LastBullet) //elimina la pelotas de la Queue
    {
        if (_ballQueue.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        _ballQueue.Dequeue();
        _indice--;
    }

    public bool ColaVacia() //verifica que la Queue no este vacia 
    {
        return (_indice == 0);
    }

    public object Primero() //devuelve el primero 
    {
        if (_ballQueue.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        return _ballQueue.Peek();
    }
}
