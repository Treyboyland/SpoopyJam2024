using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    AsteroidPool asteroidPool;

    [SerializeField]
    int initialAsteroidTier;

    [SerializeField]
    EnemyPool enemyPool;

    [SerializeField]
    bool shouldSpawn;

    [SerializeField]
    Vector2 spawnAngle;

    [Tooltip("X bounds, then Y Bounds")]
    [SerializeField]
    Vector4 startingPoints;

    [SerializeField]
    List<LevelToSpawnData> possibleData;

    float elapsed = 0;

    [Serializable]
    public struct LevelToSpawnData
    {
        public int Level;
        public float SecondsBetweenSpawn;
        public int InitialSpawn;
        public float EnemyProbability;
    }

    enum SpawnDirection
    {
        LEFT = 0,
        UP,
        RIGHT,
        DOWN
    }

    LevelToSpawnData currentData;

    // Start is called before the first frame update
    void Start()
    {
        currentData = possibleData[0];
        SpawnInitial();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            elapsed += Time.deltaTime;
            if (elapsed > currentData.SecondsBetweenSpawn)
            {
                elapsed = 0;
                SpawnItem();
            }
        }
    }

    void SpawnItem()
    {
        Vector2Int randomStart = new Vector2Int(0, 3);

        SpawnDirection spawnStart = (SpawnDirection)randomStart.Random();

        Vector2 spawnLocation;
        float startingAngle;

        //Left Up Right Down
        switch (spawnStart)
        {
            case SpawnDirection.LEFT:
                spawnLocation = new Vector2(startingPoints.x, new Vector2(startingPoints.z, startingPoints.w).Random());
                startingAngle = 90;
                break;
            case SpawnDirection.UP:
                spawnLocation = new Vector2(new Vector2(startingPoints.x, startingPoints.y).Random(), startingPoints.w);
                startingAngle = 180;
                break;
            case SpawnDirection.RIGHT:
                spawnLocation = new Vector2(startingPoints.y, new Vector2(startingPoints.z, startingPoints.w).Random());
                startingAngle = -90;
                break;
            case SpawnDirection.DOWN:
            default:
                spawnLocation = new Vector2(new Vector2(startingPoints.x, startingPoints.y).Random(), startingPoints.z);
                startingAngle = 0;
                break;
        }

        bool spawnEnemy = UnityEngine.Random.Range(0.0f, 1.0f) < currentData.EnemyProbability;

        if (spawnEnemy)
        {
            var enemy = enemyPool.GetObject();
            enemy.transform.position = spawnLocation;
            enemy.gameObject.SetActive(true);
        }
        else
        {
            var asteroid = asteroidPool.GetObject();
            asteroid.transform.position = spawnLocation;
            asteroid.CurrentTier = initialAsteroidTier;
            asteroid.DirectionQuaternion = Quaternion.Euler(0, 0, startingAngle + spawnAngle.Random());
            asteroid.gameObject.SetActive(true);
        }

    }

    public void ClearAll()
    {
        asteroidPool.DisableAll();
        enemyPool.DisableAll();
        elapsed = 0;
    }

    public void SpawnInitial()
    {
        shouldSpawn = true;
        for (int i = 0; i < currentData.InitialSpawn; i++)
        {
            SpawnItem();
        }
    }
}
