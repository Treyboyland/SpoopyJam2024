using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEventsOnEnable : MonoBehaviour
{
    [SerializeField]
    List<GameEventSO> eventsToFire;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            foreach (var item in eventsToFire)
            {
                item.Invoke();
            }
        }
    }
}
