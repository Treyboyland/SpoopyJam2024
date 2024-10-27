using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Player player;

    [SerializeField]
    List<string> levelTexts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText()
    {
        int level = Mathf.Max(Mathf.Min(player.Level, levelTexts.Count - 1), 0);
        text.text = "Time: " + levelTexts[level];
    }
}
