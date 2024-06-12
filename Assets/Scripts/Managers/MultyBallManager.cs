using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultyBallManager : ObjectManager
{
    public override void CreateObjects(Vector3 position)
    {
        GameObject mBall = ObjectPool.GetPooledObject("MultyBall");
        mBall.transform.position = new Vector3(position.x, position.y, position.z - 1);
        mBall.transform.SetParent(GameManager.Instance.multyBallManager.transform);
        mBall.SetActive(true);
    }
    public void ClearMultyBalls()
    {
        ClearObjects<MultyBall>();
    }
    public void ReturnObjects(GameObject mBall)
    {
        ReturnObject(mBall, "MultyBall");
    }
    public override void CreateObjects(int objectsToCreate)
    {
        throw new System.NotImplementedException();
    }
    //public void ClearMultyBalls()
    //{
    //    MultyBall[] activeMultyBalls = FindObjectsOfType<MultyBall>();
    //    foreach (MultyBall mBall in activeMultyBalls)
    //    {
    //        mBall.gameObject.SetActive(false);
    //    }
    //}
    //public void ReturnObjects(GameObject mBall)
    //{
    //    if (ObjectPool != null)
    //    {
    //        ObjectPool.ReturnObjectToPool(mBall, "MultyBall");
    //    }
    //}
}