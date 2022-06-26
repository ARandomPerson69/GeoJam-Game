using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObstacleController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint; 
    public GameObject bulletPrefab;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
