using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] lives;
    public void DeactivateLife(int index)
    {
        lives[index].SetActive(false);
    }
    public void ActivateLife(int index)
    {
        lives[index].SetActive(true);
    }
}
