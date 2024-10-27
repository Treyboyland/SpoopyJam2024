using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameEventVector3SO onAsteroidDestroyed;

    [SerializeField]
    GameEventVector3SO onSpawnEnergy;

    [SerializeField]
    Vector2 randomSpeed;

    [SerializeField]
    Vector2Int objectsToCreateOnDestroy;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    List<TierAndSize> tierAndSizes;

    [SerializeField]
    int currentTier;

    [SerializeField]
    float energyDropChance;

    static int currentMisses;

    public int CurrentTier
    {
        get
        {
            return currentTier;
        }
        set
        {
            currentTier = value;
            SetSize();
        }
    }

    /// <summary>
    /// Direction asteroid will go in
    /// </summary>
    public Quaternion DirectionQuaternion = Quaternion.identity;

    public AsteroidPool Pool;

    [Serializable]
    public struct TierAndSize
    {
        public int Tier;
        public float Size;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetSize()
    {
        //This is bad...but who cares?
        transform.localScale = Vector3.zero.VectorOfSize(tierAndSizes.Where(x => x.Tier == currentTier).FirstOrDefault().Size);
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        body.velocity = randomSpeed.Random() * (DirectionQuaternion * Vector3.up);
    }

    void CreateAdditional(int count)
    {
        if (Pool == null)
        {
            return;
        }
        for (int i = 0; i < count; i++)
        {
            var newAsteroid = Pool.GetObject();
            newAsteroid.transform.position = transform.position;
            newAsteroid.DirectionQuaternion = Quaternion.Euler(0, 0, new Vector2(0, 360).Random());
            newAsteroid.CurrentTier = CurrentTier - 1;
            newAsteroid.gameObject.SetActive(true);
        }
    }

    public void DestroyAsteroid()
    {
        if (CurrentTier != 1)
        {
            CreateAdditional(objectsToCreateOnDestroy.Random());
        }
        else
        {
            bool spawnEnergy = new Vector2(0, 1).Random() <= energyDropChance;
            currentMisses += spawnEnergy ? 0 : 1;

            if (spawnEnergy || currentMisses >= 1 / energyDropChance)
            {
                currentMisses = 0;
                onSpawnEnergy.Invoke(transform.position);
            }
        }

        onAsteroidDestroyed.Invoke(transform.position);
        gameObject.SetActive(false);
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
            DestroyAsteroid();
        }
    }
}
