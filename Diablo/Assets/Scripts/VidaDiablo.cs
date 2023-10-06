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

    public void SetMaxHealth(int DmaxHealth)
    {

        HPdiablo.maxValue = DmaxHealth;
        HPdiablo.value = DmaxHealth;
    }

    public void SetHealth(int DhealthActual) 
    {
        HPdiablo.value = DhealthActual;
    }
}
