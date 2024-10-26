using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Vector2 randomSpeed;

    [SerializeField]
    Vector2Int objectsToCreateOnDestroy;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    List<TierAndSize> tierAndSizes;

    int currentTier;

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
        Vector3.zero.VectorOfSize(tierAndSizes.Where(x => x.Tier == currentTier).FirstOrDefault().Size);
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        body.velocity = randomSpeed.Random() * (Quaternion.Euler(0, 0, UnityEngine.Random.Range(0.0f, 360)) * Vector3.up);
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
            newAsteroid.CurrentTier = CurrentTier - 1;
            newAsteroid.gameObject.SetActive(true);
        }
    }

    public void DestroyAsteroid()
    {
        if (CurrentTier != 0)
        {
            CreateAdditional(objectsToCreateOnDestroy.Random());
        }

        gameObject.SetActive(false);
    }
}
