using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultyBallManager : MonoBehaviour
{
    public bool inGame;

    public ObjectPool objectPool;
    [SerializeField] Transform multyBallManager;
    private void Start()
    {
        if (objectPool.poolDictionary == null || objectPool.poolDictionary.Count == 0)
        {
            objectPool.InitializePool();
        }
    }
    public void CreateObjects(Vector3 position)
    {
        if (!inGame)
        {
            GameObject mBall = objectPool.GetPooledObject("MultyBall");
            mBall.transform.position = new Vector3(position.x, position.y, position.z - 1);
            mBall.transform.SetParent(multyBallManager);
            mBall.SetActive(true);
        }
    }
    public void ReturnObjects(GameObject mBall)
    {
        if (objectPool != null)
        {
            objectPool.ReturnObjectToPool(mBall, "MultyBall");
        }
    }
}
