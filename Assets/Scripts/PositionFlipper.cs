using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFlipper : MonoBehaviour
{
    [SerializeField]
    Vector4 bounds = new Vector4(-8, 8, -6, 6);

    [SerializeField]
    Rigidbody2D body;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        var pos = transform.position;

        if ((pos.x <= bounds.x && body.velocity.x < 0)
            || (pos.x >= bounds.y && body.velocity.x > 0))
        {
            pos.x *= -1;
        }


        if ((pos.y <= bounds.z && body.velocity.y < 0)
            || (pos.y >= bounds.w && body.velocity.y > 0))
        {
            pos.y *= -1;
        }

        transform.position = pos;
    }
}
