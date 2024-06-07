using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultyBallManager : ObjectManager
{
    public bool inGame;
    protected override void Start()
    {
        base.Start();
    }
    public override void CreateObjects(Vector3 position)
    {
        if (!inGame)
        {
            GameObject mBall = objectPool.GetPooledObject("MultyBall");
            mBall.transform.position = new Vector3(position.x, position.y, position.z - 1);
            mBall.SetActive(true);
        }
    }
    public override void ClearObjects()
    {
        base.ClearObjects();
    }
    public override void ReturnObjects()
    {
        base.ReturnObjects();
    }
}
