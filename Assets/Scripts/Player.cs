using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    BulletPool bulletPool;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float thrustPower;

    [SerializeField]
    float rotationSpeed;

    public bool ShouldThrust;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if (ShouldThrust)
        {
            Thrust();
        }
    }

    public void Thrust()
    {
        body.AddForce(transform.forward * thrustPower * Time.fixedDeltaTime);
    }

    public void Rotate(float val)
    {
        transform.Rotate(0, 0, val * rotationSpeed * Time.deltaTime);
    }

    public void Fire()
    {
        var newBullet = bulletPool.GetObject();

        if (newBullet != null)
        {
            newBullet.transform.position = transform.position;
        }
    }
}
