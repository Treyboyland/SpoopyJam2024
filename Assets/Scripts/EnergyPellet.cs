using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPellet : MonoBehaviour
{
    [SerializeField]
    GameEventSO onPelletPickedUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.Energy++;
            onPelletPickedUp.Invoke();
            gameObject.SetActive(false);
        }
    }
}
