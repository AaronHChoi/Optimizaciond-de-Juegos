using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public int targetBlocksForPowerUp = 75;
    public int blocksBrocken;
    [SerializeField] private float currentChance = 0;
    MultyBallManager multyBallManager;
    private void Start()
    {
        currentChance = 100f / (targetBlocksForPowerUp / 2f);
        multyBallManager = FindObjectOfType<MultyBallManager>();
        Debug.Log("PowerUpsManager" + blocksBrocken);
    }
    public void BlockDestroyed(Vector3 lastPosition)
    {
        blocksBrocken++;

        UpdateChance();

        if (ShouldGeneratePowerUp())
        {
            GeneratePowerUp(lastPosition);
            ResetPowerUpChance();
        }
    }
    private void UpdateChance()
    {
        // Incrementamos la probabilidad de forma acumulativa
        currentChance += 100f / targetBlocksForPowerUp;

        // Aseguramos que la probabilidad no exceda el 100%
        if (currentChance > 100f)
        {
            currentChance = 100f;
        }
    }

    private bool ShouldGeneratePowerUp()
    {
        // Generamos un n�mero aleatorio y comparamos con la probabilidad actual
        float randomValue = Random.Range(0f, 100f);
        return randomValue <= currentChance;
    }

    private void GeneratePowerUp(Vector3 lastPosition)
    {
        if(multyBallManager != null)
        {

            multyBallManager.CreateObjects(lastPosition);
            // L�gica para generar el power-up
            Debug.Log("Power-up generated!");
            // Aqu� podr�as instanciar un prefab de power-up o realizar alguna otra acci�n
        }
        else
        {
            Debug.LogWarning("multyBallManager is not initialized. Cannot generate power-up.");
        }
    }

    private void ResetPowerUpChance()
    {
        Debug.Log("ResetChance");
        // Reseteamos la probabilidad de generaci�n de power-ups
        currentChance = 100f / (targetBlocksForPowerUp / 2f);
        blocksBrocken = 0;
    }
}