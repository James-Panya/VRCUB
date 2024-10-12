using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAI : MonoBehaviour
{
    public float teleportRange = 10f;
    public int maxHits = 3;
    private int currentHits = 0;
    private GameObject playerTarget;

    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        if (playerTarget == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    public void OnShot()
    {
        currentHits++;
        Debug.Log("Hits: " + currentHits);

        if (currentHits >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            TeleportAroundPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnShot();
    }

    // Teleport the enemy to a random position within the specified range of the player
    private void TeleportAroundPlayer()
    {
        if (playerTarget != null)
        {
            // Generates a random position within the teleport range around the player
            Vector3 randomOffset = Random.insideUnitSphere * teleportRange;
            randomOffset.y = 0;

            // Sets new position by adding the random offset to the player position
            transform.position = playerTarget.transform.position + randomOffset;

            transform.LookAt(playerTarget.transform.position);
        }
    }
}
