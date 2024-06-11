using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] int targetBlocksForPowerUp = 75;
    [SerializeField] int blocksBrocken;
    [SerializeField] float currentChance = 0;
    private void Start()
    {
        currentChance = 100f / (targetBlocksForPowerUp / 2f);
    }
    public void BlockDestroyed(Vector3 lastPosition)
    {
        blocksBrocken++;

        UpdateChance();

        GeneratePowerUp(lastPosition);
    }
    private void GeneratePowerUp(Vector3 lastPosition)
    {
        if (GameManager.Instance.BlockLeft <= 3 || GameManager.Instance.PowerActive) { return; }

        if (ShouldGeneratePowerUp())
        {
            GeneratePowerUpLastPosition(lastPosition);
            ResetPowerUpChance();
        }
    }
    private void UpdateChance()
    {
        currentChance += 100f / targetBlocksForPowerUp;

        if (currentChance > 100f)
        {
            currentChance = 100f;
        }
    }
    private bool ShouldGeneratePowerUp()
    {
        float randomValue = Random.Range(0f, 100f);
        return randomValue <= currentChance;
    }
    private void GeneratePowerUpLastPosition(Vector3 lastPosition)
    {
        if(GameManager.Instance.multyBallManager != null)
        {
            GameManager.Instance.multyBallManager.CreateObjects(lastPosition);
            GameManager.Instance.PowerActive = true;
        }
    }
    private void ResetPowerUpChance()
    {
        currentChance = 100f / (targetBlocksForPowerUp / 2f);
        blocksBrocken = 0;
    }
}