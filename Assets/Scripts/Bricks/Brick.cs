using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isDestroyed = false;
    private BrickManager brickManager;
    private void Start()
    {
        brickManager = GetComponent<BrickManager>();
    }
    public void ResetBrick()
    {
        isDestroyed = false;
    }
    public void DestroyBlock()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            brickManager.ReturnBrick(gameObject);
            GameManager.Instance.BlockDestroyed();
            Debug.Log(GameManager.Instance.blockLeft);
        }
    }
}
