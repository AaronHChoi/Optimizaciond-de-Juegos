using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int blockLeft;
    public HUD hud;
    public BrickManager brickManager;

    private int level;
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
        level = 1;
        Debug.Log(blockLeft);
        LoadLevel(level);
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
        level++;
        LoadLevel(level);
        hud.ChangeLevel("Level " + level);
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
    private void LoadLevel(int level)
    {
        if(brickManager != null)
        {
            int bricksToCreate = level;
            bricksToCreate *= 9;
            brickManager.CreateBricks(bricksToCreate);
            blockLeft = bricksToCreate; 
        }
    }
}