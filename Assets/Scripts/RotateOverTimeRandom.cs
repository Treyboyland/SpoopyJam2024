using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTimeRandom : MonoBehaviour
{
    [SerializeField]
    Vector2 rotationSpeed;

    float chosenSpeed;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        chosenSpeed = rotationSpeed.Random();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, chosenSpeed) * Time.deltaTime);
    }
}
