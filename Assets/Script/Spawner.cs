using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    private float countTime;
    public float spawnTime;
    private Vector3 spawnPosition;
   

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();

    }

    void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.5f, 3.5f);

        if(countTime >= spawnTime)
        {
            CreatPlatform();
            countTime = 0;
        }

    }

    void CreatPlatform()
    {
        int index = Random.Range(0, platforms.Count);
        Instantiate(platforms[index], spawnPosition, Quaternion.identity);

    }
}
