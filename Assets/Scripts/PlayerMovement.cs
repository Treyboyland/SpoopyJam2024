using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        //Debug.LogWarning($"{movementVector.y}");

        player.ShouldThrust = movementVector.y > 0;
        player.Rotate(-movementVector.x);
    }

    public void HandleFire(InputAction.CallbackContext context)
    {
        bool shouldFire = context.ReadValueAsButton();
        if (shouldFire)
        {
            player.Fire();
        }
    }
}
