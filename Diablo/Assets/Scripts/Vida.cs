using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public Slider DonHP;

    // Start is called before the first frame update
    void Start()
    {
        //sliderVida = GetComponent<Slider>(); // aqui tomas el componente de SLider y lo guardas en la variable. 
    }

    public void SetMaxHealth(int maxHealth)
    {

        DonHP.maxValue = maxHealth;
        DonHP.value = maxHealth;
    }

    public void SetHealth(int healthActual) // el SetHealth es para bautizar 
    {
        DonHP.value = healthActual;
    }
}
