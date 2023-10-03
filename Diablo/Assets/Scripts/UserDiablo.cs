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



    public GameObject[] rocks1Arr;
    GameObject rockGen1;
    private bool Arr1Active = false;
    private bool Arr1Stop = false;
    public GameObject[] rocks2Arr;
    private bool Arr2Active = false;
    GameObject rockGen2;

    public float RaiseSpeed = 100f;


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
            if (Arr1Stop == false)
            {
                if (Arr1Active == false)
                {
                    RockLayout1();
                }
            }
        }
        else if (currentHP <= 68)
        {
            Arr1Stop = true;
            Destroy(rockGen1.gameObject);
            StopCoroutine(RockRaise1(rockGen1.transform.position));
            if (Arr2Active == false)
            {
                RockLayout2();
            }
        }

        else if (currentHP == 0)
        {
            GameWin.SetActive(true);
            
        }

        void RockLayout1()
        {
            int i = Random.Range(0, rocks1Arr.Length - 1);
            //int gendRock = i;
            rockGen1 = Instantiate(rocks1Arr[i], transform);
            rockGen1.transform.position = new Vector3(0, -100, 0);
            Arr1Active = true;
            StartCoroutine(RockRaise1(rockGen1.transform.position));
        }

        void RockLayout2()
        {
            int i = Random.Range(0, rocks2Arr.Length - 1);
            rockGen2 = Instantiate(rocks2Arr[i], transform);
            rockGen2.transform.position = new Vector3(0, -100, 0);
            Arr2Active = true;
            StartCoroutine(RockRaise2(rockGen2.transform.position));
        }

        IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(5);



        }
        IEnumerator RockRaise1(Vector3 startingPos)
        {
            //Vector3 startingPos = rockGen1.transform.position;
            Vector3 endPos = Vector3.zero;
            while (Vector3.Distance(startingPos, endPos) > 0.5f)
            {

                rockGen1.transform.position = Vector3.MoveTowards(startingPos, endPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen1.transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(10);
            Destroy(rockGen1.gameObject);
            RockLayout1();

        }

        IEnumerator RockRaise2(Vector3 startingPos)
        {
            Vector3 endPos = Vector3.zero;
            while (Vector3.Distance(startingPos, endPos) > 0.5f)
            {
                rockGen2.transform.position = Vector3.MoveTowards(startingPos, endPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen2.transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(10);
            Destroy(rockGen2.gameObject);
            RockLayout2();

        }
    }



}