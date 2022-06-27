using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObstacle : MonoBehaviour
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
            //Time.time = 0; //reset da timer //Lol reset urmom my unity said this was an error
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
