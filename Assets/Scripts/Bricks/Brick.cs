using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isDestroyed = false;
    public Vector3 lastPosition;
    private BrickManager brickManager;
    private PowerUpsManager powerUpManager;
    private void Start()
    {
        brickManager = GetComponentInParent<BrickManager>();
        powerUpManager = FindObjectOfType<PowerUpsManager>();
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
            lastPosition = transform.position;
            brickManager.ReturnBrick(this.gameObject);
            GameManager.Instance.BlockDestroyed();
            powerUpManager.BlockDestroyed(lastPosition);
            Debug.Log(GameManager.Instance.blockLeft);
        }
    }
}
