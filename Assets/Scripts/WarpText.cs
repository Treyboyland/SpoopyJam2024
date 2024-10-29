using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarpText : MonoBehaviour
{
    [SerializeField]
    GameEventSO onIncreaseLevel;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    float secondsBeforeWarp;

    bool showStuff = false;
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (showStuff)
        {
            elapsed += Time.deltaTime;
            text.text = "Warp in " + string.Format("{0:N0}", secondsBeforeWarp - elapsed);

            if (elapsed >= secondsBeforeWarp)
            {
                elapsed = 0;
                showStuff = false;
                text.text = "";
                onIncreaseLevel.Invoke();
            }
        }
        else
        {
            text.text = "";
        }
    }

    public void StartShowing()
    {
        showStuff = true;
    }

    public void StopShowing()
    {
        showStuff = false;
    }
}
