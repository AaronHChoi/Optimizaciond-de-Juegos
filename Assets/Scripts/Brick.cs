using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isDestroyed = false;
    public void ResetBrick()
    {
        isDestroyed = false;
    }
}
