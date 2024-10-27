using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnThrust : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Animator controller;

    [SerializeField]
    string boolParam;

    // Update is called once per frame
    void Update()
    {
        controller.SetBool(boolParam, player.ShouldThrust);
    }
}
