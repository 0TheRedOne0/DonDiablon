using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDiablo : MonoBehaviour
{
    public int currentHP = 200;
    public int maxHP = 200;
    public int minHP = 0;
    public Slider HPdiablo;

    public GameObject GameWin;

    //Variables para el RockArray
    public GameObject[] rocks1Arr;
    public GameObject[] rocks2Arr;


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
            RockLayout1();
        }
        else if (currentHP <= 68)
        {
            RockLayout2();
        }

        else if (currentHP == 0)
        {
            GameWin.SetActive(true);

        }

        void RockLayout1()
        {
            GameObject rockGen1;
            int i = Random.Range(0, rocks1Arr.Length - 1);
            rockGen1 = Instantiate(rocks1Arr[i], transform);
            StartCoroutine(CoolDown());
            
        }

        void RockLayout2()
        {
            GameObject rockGen2;
            int i = Random.Range(0, rocks2Arr.Length - 1);
            rockGen2 = Instantiate(rocks2Arr[i], transform);
            StartCoroutine(CoolDown());
        }

        IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(5);

        }
    }
}