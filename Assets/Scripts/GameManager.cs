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

    [SerializeField] BrickManager brickManager;
    [SerializeField] PlayerController playerController;
    [SerializeField] BallArkanoid ball;

    private int level;
    private int lives = 3;
    private string win = "Win";
    private string lose = "Lose";
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
        StartCoroutine(LoadLevelCoroutine(level));
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
        if(level <= 2)
        {
            level++;
            StartCoroutine(LoadLevelCoroutine(level));
            playerController.ResetPosition();
            ball.ResetBall();
            hud.ChangeLevel("Level " + level);
        } else
            EndGame(win);
       
    }
    public void ResetScene()
    {
        if(lives <= 0)
            EndGame(lose);
    }
    public void LoseLife()
    {
        lives--;
        hud.DeactivateLife(lives);
    }
    private IEnumerator LoadLevelCoroutine(int level)
    {
        yield return null;
        if(brickManager != null)
        {
            int bricksToCreate = level * 9;
            brickManager.CreateBricks(bricksToCreate);
            
            blockLeft = bricksToCreate;
        }
    }
    public void EndGame(string result)
    {
        hud.endScreen.SetActive(true);
        hud.ChangeResult(result);
    }
}