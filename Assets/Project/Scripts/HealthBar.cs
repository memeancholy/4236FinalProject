using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour  
{
    // Creates a slider that will represent the health bar
    public Slider healthSlider;

    // Establishes maximum health
    public void MaxHealth(float health)
    {     
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    
    // Updates health based on whatever changes to it occur
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
