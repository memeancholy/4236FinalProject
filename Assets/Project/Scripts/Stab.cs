using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;

    public float damageTaken = 20f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Le Cube")
        {
            other.gameObject.GetComponent<HealthBar>();
            currentHealth -= damageTaken;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Stabbed!");
        }
    }
}
