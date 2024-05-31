using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int blockLeft;

    public HUD hud;

    private int lives = 3;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    private void Start()
    {
        blockLeft = GameObject.FindGameObjectsWithTag("Block").Length;
        Debug.Log(blockLeft);
    }
    public void BlockDestroyed()
    {
        blockLeft--;
        if(blockLeft <= 0)
        {
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ResetScene()
    {
        if(lives <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoseLife()
    {
        lives--;
        hud.DeactivateLife(lives);
    }
}