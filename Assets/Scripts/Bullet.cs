using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float lifeTime;

    [SerializeField]
    Rigidbody2D body;

    float elapsed = 0;

    public BulletTrailPool TrailPool;

    public Vector2 ForwardVector;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > lifeTime)
        {
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        elapsed = 0;
        body.velocity = ForwardVector.normalized * speed;
        if (gameObject.activeInHierarchy && TrailPool != null)
        {
            var trail = TrailPool.GetObject();
            trail.BulletToTrack = this;
            trail.gameObject.SetActive(true);
        }
    }
}
