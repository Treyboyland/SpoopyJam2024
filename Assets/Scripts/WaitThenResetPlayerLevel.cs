using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenResetPlayerLevel : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    float secondsToWait;

    [SerializeField]
    GameEventSO onLevelReset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WaitThenReset()
    {
        StartCoroutine(DoStuff());
    }

    IEnumerator DoStuff()
    {
        yield return new WaitForSeconds(secondsToWait);
        //player.Level = 0;
        onLevelReset.Invoke();
    }
}
