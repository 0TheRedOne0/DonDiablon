using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public Slider DonHP;

    // Start 
    void Start()
    {
         
    }

    public void SetMaxHealth(int maxHealth)
    {
        DonHP.maxValue = maxHealth;
        DonHP.value = maxHealth;

    }

    public void SetHealth(int healthActual) 
    {
        DonHP.value = healthActual;
    }
}
