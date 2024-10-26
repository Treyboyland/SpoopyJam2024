using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector2 frontVector;

    [SerializeField]
    BulletPool bulletPool;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float thrustPower;

    [SerializeField]
    float rotationSpeed;

    float currentRotationValue;

    public bool ShouldThrust;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        transform.Rotate(0, 0, currentRotationValue * rotationSpeed * Time.deltaTime);
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
        body.AddForce((transform.rotation * frontVector) * thrustPower * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void Rotate(float val)
    {
        currentRotationValue = val;

    }

    public void Fire()
    {
        var newBullet = bulletPool.GetObject();

        if (newBullet != null)
        {
            newBullet.transform.position = transform.position;
            newBullet.ForwardVector = transform.rotation * frontVector;
            newBullet.gameObject.SetActive(true);
        }
    }
}
