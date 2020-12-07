using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShootingScript : MonoBehaviour
{

    [Tooltip("Fire rate per second")]
    [Range(1f, 15f)]
    public float fireRate = 5f;
    private float fireDelay = 1f;
    private float fireTimer = 0f;

    public float batteryCharge = 100f;
    private float batteryLeft = 100f;
    public float batteryCostPerShot = 2f;

    //what methods to run if we are going to shoot.
    public UnityEvent shootEvent;


    // Start is called before the first frame update
    void Start()
    {
        fireDelay = 1f / fireRate;
        batteryLeft = batteryCharge;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && fireTimer > fireDelay && batteryLeft > 0)
        {
            shootEvent.Invoke();
            fireTimer = 0f;     //reset timer
            //reduce charge in battery
            batteryLeft -= batteryCostPerShot;
        }
    }

    public void RechargeBattery(float amount)
    {
        //add on battery amount and make sure it is clamped to min and max
        batteryLeft += amount;
        batteryLeft = Mathf.Clamp(batteryLeft, 0, batteryCharge);
    }

    public float GetBatteryPercent()
    {
        return (batteryLeft / batteryCharge) * 100f;
    }

}
