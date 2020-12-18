using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour
{
    public float enemyHealth = 50f;

    // Function to take away enemy health each time a raycast hits the AI object
    public void TakeDamage(float damageTaken)
    {
        enemyHealth -= damageTaken;

        // If the enemy has no more health, destroy the object
        if (enemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
