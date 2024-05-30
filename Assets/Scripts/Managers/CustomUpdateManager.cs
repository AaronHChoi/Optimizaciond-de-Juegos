using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    //[SerializeField] private BallArkanoid ballArkanoid;
    //[SerializeField] private PlayerController playerController;
    [SerializeField] private MultyBall multyBall;
    private void Update()
    {
        //ballArkanoid.CustomUpdate();
        //playerController.CustomUpdate();
        multyBall.CustomUpdate();
    }
}
