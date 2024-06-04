using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ColaTDA 
{
    // siempre que la cola este inicializada
    void Acolar(GameObject GameObject);
    // siempre que la cola este inicializada y no este vacıa
    void Desacolar(GameObject LastBall);
    // siempre que la cola este inicializada
    bool ColaVacia();
    // siempre que la cola este inicializada y no este vacıa
    object Primero();
}
