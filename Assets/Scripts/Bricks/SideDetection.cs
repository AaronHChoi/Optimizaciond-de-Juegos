using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideDetection : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Vector3 boxSize;
    private Vector3 boxCenter;
    private BallArkanoid ball;
    private void Start()
    {
        ball = GetComponent<BallArkanoid>();
        boxCollider = GetComponent<BoxCollider>();
        boxSize = boxCollider.size;
        boxCenter = boxCollider.center;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.transform.parent?.GetComponent<Brick>();
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 localHitPoint = transform.InverseTransformPoint(contact.point) - boxCenter;

            if (IsRightSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado derecho");
                //ball.UpdateVelocity(new Vector2(4, ball.initialVelocity.y > 0 ? 6 : -6));
                brick?.DestroyBlock();
            }
            else if (IsLeftSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado izquierdo");
                //ball.UpdateVelocity(new Vector2(-4, ball.initialVelocity.y > 0 ? 6 : -6));
                brick?.DestroyBlock();
            }
            else if (IsTopSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado superior");
                //ball.UpdateVelocity(new Vector2(ball.initialVelocity.x, 6));
                brick?.DestroyBlock();
            }
            else if (IsBottomSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado inferior");
                //ball.UpdateVelocity(new Vector2(ball.initialVelocity.x, -6));
                brick?.DestroyBlock();
            }
            else if (IsFrontSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado frontal");
            }
            else if (IsBackSide(localHitPoint))
            {
                Debug.Log("Contactó con el lado trasero");
            }
        }
    }
    private bool IsRightSide(Vector3 localHitPoint)
    {
        return localHitPoint.x > boxSize.x / 2 - 0.01f;
    }
    private bool IsLeftSide(Vector3 localHitPoint)
    {
        return localHitPoint.x < -boxSize.x / 2 + 0.01f;
    }
    private bool IsTopSide(Vector3 localHitPoint)
    {
        return localHitPoint.y > boxSize.y / 2 - 0.01f;
    }
    private bool IsBottomSide(Vector3 localHitPoint)
    {
        return localHitPoint.y < -boxSize.y / 2 + 0.01f;
    }
    private bool IsFrontSide(Vector3 localHitPoint)
    {
        return localHitPoint.z > boxSize.z / 2 - 0.01f;
    }
    private bool IsBackSide(Vector3 localHitPoint)
    {
        return localHitPoint.z < -boxSize.z / 2 + 0.01f;
    }
}