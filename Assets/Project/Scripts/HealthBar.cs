using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour  
{
    public Slider healthSlider;

    public void MaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
