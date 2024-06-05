using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideDetection : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Vector3 boxSize;
    private Vector3 boxCenter;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxSize = boxCollider.size;
        boxCenter = boxCollider.center;
    }
    public string GetHitSide(Vector3 hitPoint)
    {
        Vector3 localHitPoint = transform.InverseTransformPoint(hitPoint) - boxCenter;
       
        if (IsRightSide(localHitPoint))
        {
            return "Right";
        }
        else if (IsLeftSide(localHitPoint))
        {
            return "Left";
        }
        else if (IsTopSide(localHitPoint))
        {
            return "Top";
        }
        else if (IsBottomSide(localHitPoint))
        {
            return "Bottom";
        }
        return "Unkown";
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
}