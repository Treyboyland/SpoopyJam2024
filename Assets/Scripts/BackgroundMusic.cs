using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (player.Level == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else if (player.Level > 0 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
