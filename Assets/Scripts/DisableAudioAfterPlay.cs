using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAudioAfterPlay : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

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
        source.Play();

        while (source.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
