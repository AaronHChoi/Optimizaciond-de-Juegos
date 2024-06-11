using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultyBallManager : MonoBehaviour
{
    public ObjectPool ObjectPool;
    private void Awake()
    {
        if (ObjectPool.poolDictionary == null || ObjectPool.poolDictionary.Count == 0)
        {
            ObjectPool.InitializePool();
        }
    }
    public void CreateObjects(Vector3 position)
    {
        GameObject mBall = ObjectPool.GetPooledObject("MultyBall");
        mBall.transform.position = new Vector3(position.x, position.y, position.z - 1);
        mBall.transform.SetParent(GameManager.Instance.multyBallManager.transform);
        mBall.SetActive(true);
    }
    public void ClearMultyBalls()
    {
        MultyBall[] activeMultyBalls = FindObjectsOfType<MultyBall>();
        foreach (MultyBall mBall in activeMultyBalls)
        {
            mBall.gameObject.SetActive(false);
        }
    }
    public void ReturnObjects(GameObject mBall)
    {
        if (ObjectPool != null)
        {
            ObjectPool.ReturnObjectToPool(mBall, "MultyBall");
        }
    }
}
