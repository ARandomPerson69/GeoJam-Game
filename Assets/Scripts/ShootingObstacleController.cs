using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObstacleController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint; 
    public GameObject bulletPrefab;

    private float startTime;
    public float shootingInterval; //how often the obstacle should shoot

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        Debug.Log(t);
        if (t > shootingInterval) //if the current time has elapsed require interval time, fire bullet
        {
            Debug.Log("fire");
            Shoot();
            startTime= 0; //reset da timer (fix this hot mess later)
        }
    }

    void FixedUpdate()
    {
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
