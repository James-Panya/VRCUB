using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootInterval = 2f; 
    public float shootPower = 15f; 
    public float lookSpeed = 2f; 

    private float timeSinceLastShot;

    void Start()
    {
        timeSinceLastShot = 0f;
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);

        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody enemyBullet = bullet.GetComponent<Rigidbody>();
        enemyBullet.AddForce(transform.forward * shootPower, ForceMode.Impulse);
    }
}
