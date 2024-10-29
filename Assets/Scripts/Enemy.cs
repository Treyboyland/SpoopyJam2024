using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameEventVector3SO onEnemyDestroyed;

    [SerializeField]
    GameEventVector3SO onSpawnEnergy;

    [SerializeField]
    float energyDropChance = 0;

    static int currentMisses = 0;


    public void DestroyEnemy()
    {
        onEnemyDestroyed.Invoke(transform.position);
        bool spawnEnergy = new Vector2(0, 1).Random() <= energyDropChance;
        currentMisses += spawnEnergy ? 0 : 1;

        if (spawnEnergy || currentMisses >= 1 / energyDropChance)
        {
            currentMisses = 0;
            onSpawnEnergy.Invoke(transform.position);
        }

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.DestroyShip();
            DestroyEnemy();
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.gameObject.SetActive(false);
            DestroyEnemy();
        }
    }
}
