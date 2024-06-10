using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool IsDestroyed = false;
    public Vector3 LastPosition;
    public void ResetBrick()
    {
        IsDestroyed = false;
    }
    public void DestroyBlock()
    {
        var gameManager = GameManager.Instance;
        if (!IsDestroyed)
        {
            IsDestroyed = true;
            LastPosition = transform.position;
            gameManager.brickManager.ReturnBrick(this.gameObject);
            gameManager.BlockDestroyed();
            gameManager.powerUpsManager.BlockDestroyed(LastPosition);
        }
    }
}
