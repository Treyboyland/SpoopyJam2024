using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeonController : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    GameObject aeon;

    [SerializeField]
    private Vector4 startingPoints;

    [SerializeField]
    List<float> secondsPerLevel;

    float elapsed, secondsToWait;

    enum SpawnDirection
    {
        LEFT = 0,
        UP,
        RIGHT,
        DOWN
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetAeon();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= secondsToWait && !aeon.activeInHierarchy)
        {
            aeon.transform.position = GetRandomSpawnPosition();
            aeon.SetActive(true);
        }
    }

    public void ResetAeon()
    {
        elapsed = 0;
        aeon.SetActive(false);
        secondsToWait = secondsPerLevel[player.Level.Constrain(0, secondsPerLevel.Count - 1)];
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
}
