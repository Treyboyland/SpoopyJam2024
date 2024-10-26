using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent-On", menuName = "Game/Events/No Param", order = 0)]
public class GameEventSO : ScriptableObject
{
    List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void AddListener(GameEventListener gameEventListener)
    {
        if (!eventListeners.Contains(gameEventListener))
        {
            eventListeners.Add(gameEventListener);
        }
    }

    public void RemoveListener(GameEventListener gameEventListener)
    {
        eventListeners.Remove(gameEventListener);
    }

    public void Invoke()
    {
        foreach (var listener in eventListeners)
        {
            if (listener != null)
            {
                listener.Response.Invoke();
            }
        }
    }
}
