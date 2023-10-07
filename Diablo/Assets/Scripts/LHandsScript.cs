using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHandsScript : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private float handsSpeed = 0.0f;
    [SerializeField] private float handsFollowRate = 0f;

    public GameObject LeftHandPos;
    public GameObject LH;

    //public bool LHdie=false;
    //public int numLH = 1;

    public bool cooldown = false;

    private GameObject spawnedHand;

    private Vector3 leftPos;
    private Quaternion leftRot;

    int hpHands = 3;


    // Start is called before the first frame update
    void Start()
    {
     leftRot = new Quaternion(-4.724f, 184.418f, -7.584f, 1f);
        leftPos = LeftHandPos.transform.position;
    }
    /*void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Llama4");
            StartCoroutine(waitNdie());
            Debug.Log("Llama5");
        }
        else if (collision.gameObject.tag == "Obstacle")
        {

            Debug.Log("Llama4");
            StartCoroutine(waitNdie());
            Debug.Log("Llama5");
        }
        else if (collision.gameObject.tag == "DonBalas")
        {
            hpHands--;
            if (hpHands <= 0)
            {
                StartCoroutine(dieNwait());
            }


        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine(waitNdie());
            
        }
        else if (other.gameObject.tag == "Obstacle")
        {

            StartCoroutine(waitNdie());
            
        }
        else if (other.gameObject.tag == "DonBalas")
        {
            hpHands--;
            if (hpHands <= 0f)
            {
                StartCoroutine(dieNwait());
            }


        }
    }



    // Update is called once per frame
    void Update()
    {
        HandsAttk();
        //DIE();
        

    }

    void HandsAttk()
    {
        if (cooldown == false)
        {
            Quaternion desireRotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desireRotation, handsFollowRate * Time.deltaTime);

            transform.Translate(Vector3.forward * Time.deltaTime * handsSpeed);
        } 
    }

    void DIE()
    {
        if (hpHands <= 0)
        {
            StartCoroutine(dieNwait());
        }
        else
        {
            StartCoroutine(waitNdie());
        }
    }

    IEnumerator waitNdie()
    {
        Debug.Log("Llama");
        yield return new WaitForSeconds(2f);     
        transform.position = leftPos;
        transform.rotation = leftRot;
        cooldown = true;
        yield return new WaitForSeconds(3f);
        cooldown = false;
    }

    IEnumerator dieNwait()
    {
        if (hpHands <= 0)
        {
            transform.position = leftPos;
            transform.rotation = leftRot;
            cooldown = true;
            yield return new WaitForSeconds(3f);
            cooldown = false;
            hpHands = 3;
        }
    }


}

   /* private void OnDestroy()
    {
        //spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        spawnedHand = Instantiate(LH, leftPos, Quaternion.identity);
        //LeftHand.SetActive(true);
         spawnedHand.SetActive(true);

    // Si el componente de script está desactivado, actívalo
    LHandsScript lHandScript = spawnedHand.GetComponent<LHandsScript>();
    if (lHandScript != null)
    {
        lHandScript.enabled = true;
    }
    }*/

