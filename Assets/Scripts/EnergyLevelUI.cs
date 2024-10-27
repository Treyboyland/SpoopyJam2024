using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyLevelUI : MonoBehaviour
{
    [SerializeField]
    GameEventSO onEnergyReached;

    [SerializeField]
    Player player;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    List<int> requiredEnergyPerLevel;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        int level = Mathf.Max(Mathf.Min(player.Level, requiredEnergyPerLevel.Count - 1), 0);

        int requiredEnergy = requiredEnergyPerLevel[level];

        text.text = "Energy: " +
        (player.Energy >= requiredEnergy ? "100%" : string.Format("{0:P0}", 1.0 * player.Energy / requiredEnergyPerLevel[level]));

        if (player.Energy >= requiredEnergy)
        {
            onEnergyReached.Invoke();
        }
    }
}
