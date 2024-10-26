using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BulletTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    public Bullet BulletToTrack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BulletToTrack != null)
        {
            if (BulletToTrack.gameObject.activeInHierarchy)
            {
                transform.position = BulletToTrack.transform.position;

                if (!particle.isPlaying)
                {
                    particle.Play();
                }
            }
            else
            {
                BulletToTrack = null;
            }

        }
        else
        {
            particle.Stop();
        }

        if (particle.particleCount == 0 && !particle.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        BulletToTrack = null;
    }
}
