using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDiablo : MonoBehaviour
{
    int currentHP = 200;
    public int maxHP = 200;
    public int minHP = 0;
    public Slider HPdiablo;

    public GameObject GameWin;


    // first frame update
    void Start()
    {
        
    }

    //once per frame
    void Update()
    {
        Flags();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BulletDon")
        {
            Destroy(collision.gameObject);
            currentHP --;
            SetHealth(currentHP);
        }
    }

    public void SetMaxHealth(int maxHealth)
    {

        HPdiablo.maxValue = maxHealth;
        HPdiablo.value = maxHealth;
    }

    public void SetHealth(int healthActual) // el SetHealth es para bautizar 
    {
        HPdiablo.value = healthActual;
    }
    void Flags()
    {
        if (currentHP <= 134)
        {
            

        }
        else if (currentHP <= 68)
        {
            

        }

        else if (currentHP == 0)
        {
            GameWin.SetActive(true);

        }
    }
}