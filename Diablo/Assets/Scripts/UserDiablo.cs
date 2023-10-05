using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDiablo : MonoBehaviour
{
   //VIDA DIABLO
    public int currentHealth = 200;
    public int maxHealth = 200;
    public int minHealth = 0;
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
        currentHealth = maxHealth;
        //HPdiablo.SetMaxHealth(maxHealth);
    }

    //once per frame
    void Update()
    {
        Flags();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DonBalas")
        {
           
            currentHealth--;
            SetHealth(currentHealth);
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
        if (currentHealth <= 134)
        {
            if (Arr1Stop == false)
            {
                if (Arr1Active == false)
                {
                    RockLayout1();
                }
            }
        }
        else if (currentHealth <= 68)
        {
            Arr1Stop = true;
            Destroy(rockGen1.gameObject);
            StopCoroutine(RockRaise1(rockGen1.transform.position));
            if (Arr2Active == false)
            {
                RockLayout2();
            }
        }

        else if (currentHealth == 0)
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

       /* IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(5);



        }*/
        IEnumerator RockRaise1(Vector3 startingPos)
        {
            //Vector3 startingPos = rockGen1.transform.position;
            Vector3 endPos = Vector3.zero;
            Vector3 downPos = new Vector3(0f, -100f, 0f);
            while (Vector3.Distance(startingPos, endPos) > 0.5f)
            {

                rockGen1.transform.position = Vector3.MoveTowards(startingPos, endPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen1.transform.position;
                yield return null;
            } 
                yield return new WaitForSeconds(10);

            while (Vector3.Distance(startingPos, downPos) > 0.5f)
            {

                rockGen1.transform.position = Vector3.MoveTowards(startingPos, downPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen1.transform.position;
                yield return null;
            }
                yield return new WaitForSeconds(3);
                Destroy(rockGen1.gameObject);
                RockLayout1();
            
        }

        IEnumerator RockRaise2(Vector3 startingPos)
        {
            Vector3 endPos = Vector3.zero;
            Vector3 downPos = new Vector3(0f, -100f, 0f);
            while (Vector3.Distance(startingPos, endPos) > 0.5f)
            {
                rockGen2.transform.position = Vector3.MoveTowards(startingPos, endPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen2.transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(10);

            while (Vector3.Distance(startingPos, downPos) > 0.5f)
            {

                rockGen1.transform.position = Vector3.MoveTowards(startingPos, downPos, Time.deltaTime * RaiseSpeed);
                startingPos = rockGen1.transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            Destroy(rockGen2.gameObject);
            RockLayout2();

        }
    }



}