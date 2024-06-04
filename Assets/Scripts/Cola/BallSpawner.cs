using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private ColaTDA ballQueue = new ColaTF();
    [SerializeField] private int ballToLoad;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        LoadBalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall(int ballsToInstanciate)
    {
        if (!ballQueue.ColaVacia())
        {
            for(int i =0 ; i < ballsToInstanciate; i++) 
            {
                Quaternion RandomRotation = new Quaternion(0, 0, Random.Range(-90, 90), 0);
                //GameObject ballToSpawn = Instantiate((GameObject)ballQueue.Primero(), spawnPoint.position, spawnPoint.rotation);
                GameObject ballToSpawn = Instantiate((GameObject)ballQueue.Primero(), spawnPoint.position, RandomRotation);
                ballQueue.Desacolar(ballToSpawn);
            }
            
        }
    }

    private void LoadBalls()
    {
        for (int i = 0; i < ballToLoad; i++)
        {
            ballQueue.Acolar(ballPrefab);
        }
    }
}
