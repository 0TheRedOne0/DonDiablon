using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDiablo : MonoBehaviour
{

    public Slider HPdiablo;

    // Start 
    void Start()
    {
         
    }

    public void SetMaxHealth(int maxHealth)
    {

        HPdiablo.maxValue = maxHealth;
        HPdiablo.value = maxHealth;
    }

    public void SetHealth(int healthActual) 
    {
        HPdiablo.value = healthActual;
    }
}
