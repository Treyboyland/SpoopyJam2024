using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterParticlePlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (particle.isPlaying || particle.particleCount != 0)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
