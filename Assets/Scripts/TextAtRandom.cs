using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAtRandom : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    List<string> possibleStrings;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        text.text = possibleStrings.Random();
    }
}
