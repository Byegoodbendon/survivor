using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    private float spawnCounter;
    public float spawnTime;
    public Transform minSpawn, maxSpawn, mapMin, mapMax;
    private Transform target;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<WaveInfo> waves;
    private int currentWave;
    private float waveCount;
    private float randomX;
    private float randomY;

    void Start()
    {
        spawnCounter = spawnTime;
        target = PlayerHealthController.instance.transform;
        currentWave = -1;
        GoToNextWave();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0)
        {
            //Instantiate(enemyToSpawn,transform.position,transform.rotation);
            Instantiate(enemyToSpawn,SelectSpawnPoint(),transform.rotation);

            spawnCounter = spawnTime;
        }*/
        transform.position = target.position;

        if(PlayerHealthController.instance.gameObject.activeSelf == true)
        {
            if(currentWave < waves.Count)
            {
                waveCount -= Time.deltaTime;
                if(waveCount <= 0)
                {
                    GoToNextWave();
                }
                spawnCounter -= Time.deltaTime;
                if(spawnCounter <= 0)
                {
                    spawnCounter = waves[currentWave].timeBetweenSpawn;
                    GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, SelectSpawnPoint(),Quaternion.identity);
                    //spawnedEnemies.Add(newEnemy);
                }
            }
        }

        
    }
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f,1f)>0.5f;
        if(PlayerController.instance.transform.localScale.x > 0)
        {
            randomX = 0.9f ;
        }else
        {
            randomX = 0.1f;
        }
        if(PlayerController.instance.transform.localScale.y > 0)
        {
            randomY = 0.9f ;
        }else
        {
            randomY = 0.1f;
        }
        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y,maxSpawn.position.y);
            if(Random.Range(0f,1f) > randomX)
            {
                spawnPoint.x = minSpawn.position.x ;
            }else
            {
                spawnPoint.x = maxSpawn.position.x;
            }
        }else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x,maxSpawn.position.x);
            if(Random.Range(0f,1f) > randomY)
            {
                spawnPoint.y = minSpawn.position.y ;
            }else
            {
                spawnPoint.y = maxSpawn.position.y;
            }

        }
        if(minSpawn.position.x < mapMin.position.x && spawnPoint.x < mapMin.position.x)
        {
            spawnPoint.x = 2 * target.position.x - spawnPoint.x;
        }
        if(minSpawn.position.y < mapMin.position.y && spawnPoint.y < mapMin.position.y)
        {
            spawnPoint.y = 2 * target.position.y - spawnPoint.y;
        }
        if(maxSpawn.position.x > mapMax.position.x && spawnPoint.x > mapMax.position.x)
        {
            spawnPoint.x = 2 * target.position.x - spawnPoint.x;
        }
        if(maxSpawn.position.y > mapMax.position.y && spawnPoint.y > mapMax.position.y)
        {
            spawnPoint.y = 2 * target.position.y - spawnPoint.y;
        }

        return spawnPoint;

    }

    public void GoToNextWave()
    {
        currentWave += 1;
        if(currentWave >= waves.Count)
        {
            currentWave = waves.Count-1;
        }
        waveCount = waves[currentWave].waveTime;
        spawnCounter = waves[currentWave].timeBetweenSpawn;

    }
}

[System.Serializable]
public class WaveInfo
{
    public GameObject enemyToSpawn;
    public float waveTime;
    public float timeBetweenSpawn;
}
