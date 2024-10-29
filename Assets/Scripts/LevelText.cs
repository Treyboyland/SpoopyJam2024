using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Player player;

    [SerializeField]
    List<string> levelTexts;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        int level = player.Level.Constrain(0, levelTexts.Count - 1);
        text.text = "Time: " + levelTexts[level];
        animator.SetTrigger("Animate");
    }
}
