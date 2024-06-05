using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isDestroyed = false;
    private BrickManager brickManager;
    private PowerUpsManager powerUpManager;
    private void Start()
    {
        brickManager = GetComponentInParent<BrickManager>();
        powerUpManager = GetComponentInParent<PowerUpsManager>();
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
            brickManager.ReturnBrick(this.gameObject);
            GameManager.Instance.BlockDestroyed();
            powerUpManager.BlockDestroyed();
            Debug.Log(GameManager.Instance.blockLeft);
        }
    }
}
