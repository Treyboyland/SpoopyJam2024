using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    ParticleSystem planetParticles;

    [SerializeField]
    ParticleSystem starParticles;



    // Start is called before the first frame update
    void Start()
    {
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        planetParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        starParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        
        if (player.Level == 0)
        {
            planetParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            starParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else if (player.Level == 1)
        {
            planetParticles.Play();
            starParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else
        {
            planetParticles.Play();
            starParticles.Play();
        }
    }
}
