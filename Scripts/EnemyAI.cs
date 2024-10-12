using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameObject playerTarget;

    // When the player enters the trigger, assign it as a target
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTarget = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);  // Destroy the enemy when hit by a bullet
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only move forward if there is a player target
        if (playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}