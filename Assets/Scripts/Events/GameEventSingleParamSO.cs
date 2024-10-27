using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameEventSingleParamSO<T> : ScriptableObject
{
    List<GameEventListenerSingleParam<T>> eventListeners = new List<GameEventListenerSingleParam<T>>();

    public T Value;

    public void AddListener(GameEventListenerSingleParam<T> gameEventListener)
    {
        if (!eventListeners.Contains(gameEventListener))
        {
            eventListeners.Add(gameEventListener);
        }
    }

    public void RemoveListener(GameEventListenerSingleParam<T> gameEventListener)
    {
        eventListeners.Remove(gameEventListener);
    }

    public void Invoke()
    {
        foreach (var listener in eventListeners)
        {
            if (listener != null)
            {
                listener.Response.Invoke(Value);
            }
        }
    }

    public void Invoke(T newVal)
    {
        Value = newVal;
        Invoke();
    }
}
