using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour
{
    public float enemyHealth = 50f;

    public void TakeDamage(float damageTaken)
    {
        enemyHealth -= damageTaken;

        if (enemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
