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
    public int ballsInGame;

    [SerializeField] BrickManager brickManager;
    [SerializeField] PlayerController playerController;
    [SerializeField] BallManager ballManager;

    [SerializeField] private int level;
    private int bricksToCreate;
    private int bricks = 9;
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
        ballsInGame = 0;
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
            level++;
            if (level <= 2)
                LoadNextLevel();
            else
                EndGame(win);
        }
    }
    private void LoadNextLevel()
    {
        ballManager.ClearBalls();

        bricksToCreate = level * bricks;
        brickManager.CreateBricks(bricksToCreate);

        blockLeft = bricksToCreate;
        ballManager.CreateBalls(1);
        
        playerController.ResetPosition();

        BallArkanoid ball = FindObjectOfType<BallArkanoid>();
        if (ball != null)
            ball.ResetBall();

        hud.ChangeLevel("Level " + level);
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
            bricksToCreate = level * bricks;
            brickManager.CreateBricks(bricksToCreate);
            
            blockLeft = bricksToCreate;
            ballManager.CreateBalls(1);
        }
    }
    private void EndGame(string result)
    {
        hud.endScreen.SetActive(true);
        hud.ChangeResult(result);
    }
}