using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementStraightPeriodic : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float speed;

    [SerializeField]
    float secondsBetweenUpdates;

    [SerializeField]
    bool lookTowardsPlayer;

    [SerializeField]
    Vector3 initalForwardLook;


    float elapsed;

    static Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > secondsBetweenUpdates)
        {
            elapsed = 0;
            UpdateVelocity();
            UpdateRotation();
        }
    }

    void UpdateVelocity()
    {
        if (player == null)
        {
            return;
        }

        var directionVector = (player.transform.position - transform.position).normalized;

        body.velocity = directionVector * speed;
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        elapsed = 0;
        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
        }
        UpdateVelocity();
        UpdateRotation();
    }

    void UpdateRotation()
    {
        if (player == null)
        {
            return;
        }

        //Shamelessly pulled from https://gamedev.stackexchange.com/questions/186283/rotating-towards-a-target-in-top-down-2d-game
        var distance = player.transform.position - transform.position;

        float angle = Vector3.SignedAngle(initalForwardLook, distance, transform.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
