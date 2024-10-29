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
        player.ThrustPercentage = Mathf.Abs(movementVector.y);
        player.Rotate(-movementVector.x);
    }

    public void HandleMovementTwinStick(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        player.ShouldThrust = movementVector != Vector2.zero;
        player.SetDirection(movementVector);
    }

    public void HandleFire(InputAction.CallbackContext context)
    {
        bool shouldFire = context.ReadValueAsButton();
        if (shouldFire && context.started)
        {
            player.Fire();
        }
    }

    public void HandleFireMouse(InputAction.CallbackContext context)
    {
        bool shouldFire = context.ReadValueAsButton();
        player.ShouldFire = shouldFire;
        player.UseMouse = true;
        if (shouldFire)
        {
            player.FireMouse();
        }
    }

    public void HandleFireTwinStick(InputAction.CallbackContext context)
    {
        Vector2 fireDirection = context.ReadValue<Vector2>();
        bool previousFireState = player.ShouldFire;
        player.ShouldFire = fireDirection != Vector2.zero;
        player.UseMouse = false;
        
        if (fireDirection != Vector2.zero)
        {
            player.LastFireDirection = fireDirection;
        }
        if (fireDirection != Vector2.zero && previousFireState != player.ShouldFire)
        {
            player.Fire(fireDirection);
        }
    }
}
