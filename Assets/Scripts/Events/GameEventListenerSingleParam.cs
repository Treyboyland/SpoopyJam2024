using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListenerSingleParam<T> : MonoBehaviour
{
    [SerializeField]
    GameEventSingleParamSO<T> gameEventSO;

    public UnityEvent<T> Response;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        gameEventSO.AddListener(this);
    }

    private void OnDisable()
    {
        gameEventSO.RemoveListener(this);
    }
}
