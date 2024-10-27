using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeonCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckStuff(GameObject other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            return;
        }

        var bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            other.SetActive(false);
            return;
        }

        var asteroid = other.GetComponent<Asteroid>();

        if (asteroid != null)
        {
            asteroid.DestroyAsteroid();
            return;
        }

        var energy = other.GetComponent<EnergyPellet>();

        if (energy != null)
        {
            other.SetActive(false);
            return;
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckStuff(other.gameObject);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckStuff(other.gameObject);
    }
}
