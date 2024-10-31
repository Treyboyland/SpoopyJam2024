using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompletionCheck : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    GameEventSO gameCompletionEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckCompletion()
    {
        if (player.Level > player.MaxLevel)
        {
            gameCompletionEvent.Invoke();
        }
    }
}
