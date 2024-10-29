using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    AsteroidPool asteroidPool;

    [SerializeField]
    int initialAsteroidTier;

    [SerializeField]
    EnemyPool enemyPool;

    [SerializeField]
    int enemiesPerAsteroid;

    [SerializeField]
    bool shouldSpawn;

    [SerializeField]
    Vector2 spawnAngle;

    [Tooltip("X bounds, then Y Bounds")]
    [SerializeField]
    Vector4 startingPoints;

    [Tooltip("X bounds, then Y Bounds")]
    [SerializeField]
    Vector4 endingPoints;

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
            if (!asteroidPool.AreAnyActive() && !enemyPool.AreAnyActive())
            {
                for (int i = 0; i < currentData.InitialSpawn; i++)
                {
                    SpawnItem();
                }
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2Int randomStart = new Vector2Int(0, 3);

        SpawnDirection spawnStart = (SpawnDirection)randomStart.Random();

        Vector2 spawnLocation;

        //Left Up Right Down
        switch (spawnStart)
        {
            case SpawnDirection.LEFT:
                spawnLocation = new Vector2(startingPoints.x, new Vector2(startingPoints.z, startingPoints.w).Random());
                break;
            case SpawnDirection.UP:
                spawnLocation = new Vector2(new Vector2(startingPoints.x, startingPoints.y).Random(), startingPoints.w);
                break;
            case SpawnDirection.RIGHT:
                spawnLocation = new Vector2(startingPoints.y, new Vector2(startingPoints.z, startingPoints.w).Random());
                break;
            case SpawnDirection.DOWN:
            default:
                spawnLocation = new Vector2(new Vector2(startingPoints.x, startingPoints.y).Random(), startingPoints.z);
                break;
        }

        return spawnLocation;
    }

    void SpawnItem()
    {
        bool spawnEnemy = UnityEngine.Random.Range(0.0f, 1.0f) < currentData.EnemyProbability;

        if (spawnEnemy)
        {
            for (int i = 0; i < enemiesPerAsteroid; i++)
            {
                Vector2 spawnLocation = GetRandomSpawnPosition();
                var enemy = enemyPool.GetObject();
                enemy.transform.position = spawnLocation;
                enemy.gameObject.SetActive(true);
            }
        }
        else
        {
            Vector2 spawnLocation = GetRandomSpawnPosition();
            var asteroid = asteroidPool.GetObject();
            Vector2 target = endingPoints.Random();
            float angle = Vector2.Angle(spawnLocation, target);
            asteroid.transform.position = spawnLocation;
            asteroid.CurrentTier = initialAsteroidTier;
            asteroid.DirectionQuaternion = Quaternion.Euler(0, 0, angle);
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

    public void UpdateLevel()
    {
        currentData = possibleData[player.Level.Constrain(0, possibleData.Count - 1)];
    }
}
