using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeScreenshot()
    {
        var time = DateTime.Now;
        string fileName = "Screenshot-" + time.ToString("yyyy-MM-dd_HH-mm-ss-fff") + ".png";
        Debug.LogWarning(fileName);

        ScreenCapture.CaptureScreenshot(Application.dataPath + $"../Logs/{fileName}");
    }
}
