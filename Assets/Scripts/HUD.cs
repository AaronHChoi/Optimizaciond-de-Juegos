using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] lives;
    public TextMeshProUGUI level;
    public void ChangeLevel(string newText)
    {
        level.text = newText;
    }
    public void DeactivateLife(int index)
    {
        lives[index].SetActive(false);
    }
    public void ActivateLife(int index)
    {
        lives[index].SetActive(true);
    }
}
