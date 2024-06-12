using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int BlockLeft;
    public int BallsInGame;
    public bool PowerActive = false;
    public AudioClip WinSFX;
    public AudioClip LoseSFX;
    public HUD Hud;
    public BrickManager brickManager;
    public PlayerController playerController;
    public BallManager ballManager;
    public BallArkanoid ball;
    public LoseTrigger loseTrigger;
    public MultyBallManager multyBallManager;
    public PowerUpsManager powerUpsManager;

    [SerializeField] int level;
    int bricksToCreate;
    int bricks = 9;
    int lives = 3;
    string win = "Win";
    string lose = "Lose";
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
        BallsInGame = 0;
        BlockLeft = GameObject.FindGameObjectsWithTag("Block").Length;
        level = 1;
        StartCoroutine(LoadLevelCoroutine(level));
    }
    public void BlockDestroyed()
    {
        BlockLeft--;
        if(BlockLeft <= 0)
        {
            level++;
            if (level <= 2)
                StartCoroutine(LoadLevelCoroutine(level));
            else
            {
                AudioManager.Instance.PlaySFX(WinSFX);
                EndGame(win);
            }
        }
    }
    public void ResetScene()
    {
        if(lives <= 0)
        {
            AudioManager.Instance.PlaySFX(LoseSFX);
            EndGame(lose);
        }
    }
    public void LoseLife()
    {
        lives--;
        Hud.DeactivateLife(lives);
    }
    private IEnumerator LoadLevelCoroutine(int level)
    {
        ballManager.ClearBalls();
        multyBallManager.ClearMultyBalls();
        Hud.ChangeLevel("Level " + level);
        yield return new WaitForSeconds(0.5f);

        if(brickManager != null)
        {
            bricksToCreate = level * bricks;
            brickManager.CreateObjects(bricksToCreate);
            
            BlockLeft = bricksToCreate;
            ballManager.CreateObjects(1);
        }
        playerController.ResetPosition();
    }
    private void EndGame(string result)
    {
        Hud.endScreen.SetActive(true);
        Hud.ChangeResult(result);
        Time.timeScale = 0f;
    }
}