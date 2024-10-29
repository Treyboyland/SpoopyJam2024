using System;
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
    GameEventVector3SO onShipDestroyed;

    [SerializeField]
    GameEventSO onPlayerFire;

    [SerializeField]
    float thrustPower;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float secondsBetweenShots;

    [SerializeField]
    float maxLevelSecondsBetweenShots;

    float currentRotationValue;

    public bool ShouldThrust;

    public int Energy;
    public float ThrustPercentage = 1;

    Vector2 directionToThrust;

    public int Level;

    public int MaxLevel;

    float elapsedFireTime;
    public bool ShouldFire;

    public bool UseMouse;

    Vector2 lastFireDirection;

    public Vector2 LastFireDirection { get => lastFireDirection; set => lastFireDirection = value; }

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

    public void SetDirection(Vector2 dir)
    {
        directionToThrust = dir;
        ThrustPercentage = directionToThrust.magnitude < 1 ? directionToThrust.magnitude : 1;
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(frontVector, directionToThrust));
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if (ShouldThrust)
        {
            ThrustForward();
        }
        if (ShouldFire)
        {
            elapsedFireTime += Time.deltaTime;
            if (elapsedFireTime >= (Level >= MaxLevel ? maxLevelSecondsBetweenShots : secondsBetweenShots))
            {
                elapsedFireTime = 0;
                if (UseMouse)
                {
                    FireMouse();
                }
                else
                {
                    Fire(LastFireDirection);
                }
            }
        }
    }

    public void ThrustForward()
    {
        body.AddForce((transform.rotation * frontVector) * ThrustPercentage * thrustPower * Time.fixedDeltaTime, ForceMode2D.Impulse);
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
            newBullet.ShipSpeed = body.velocity;
            newBullet.gameObject.SetActive(true);
            onPlayerFire.Invoke();
        }
    }

    public void Fire(Vector2 fireDirection)
    {
        var newBullet = bulletPool.GetObject();
        LastFireDirection = fireDirection;

        if (newBullet != null)
        {
            newBullet.transform.position = transform.position;
            newBullet.ForwardVector = fireDirection;
            newBullet.ShipSpeed = body.velocity;
            newBullet.gameObject.SetActive(true);
            onPlayerFire.Invoke();
        }
    }

    public void FireMouse()
    {
        var newBullet = bulletPool.GetObject();

        if (newBullet != null)
        {
            newBullet.transform.position = transform.position;
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newBullet.ForwardVector = mousePos - transform.position;
            newBullet.ShipSpeed = body.velocity;
            newBullet.gameObject.SetActive(true);
            onPlayerFire.Invoke();
        }
    }

    public void IncreaseLevel()
    {
        Level++;
    }

    public void DecreaseLevel()
    {
        Level--;
        if (Level < 0)
        {
            Level = 0;
        }
    }

    public void ResetEnergy()
    {
        Energy = 0;
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(true);
    }

    public void DestroyShip()
    {
        onShipDestroyed.Invoke(transform.position);
        gameObject.SetActive(false);
    }
}
