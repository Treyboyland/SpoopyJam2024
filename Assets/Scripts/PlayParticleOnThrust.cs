using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnThrust : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    [SerializeField]
    Player player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.ShouldThrust && !particle.isEmitting)
        {
            particle.Play();
        }
        else if (!player.ShouldThrust && particle.isEmitting)
        {
            particle.Stop();
        }
    }
}
