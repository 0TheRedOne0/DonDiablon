using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHandsScript : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private float  handsSpeed =0.0f;
    [SerializeField] private float handsFollowRate = 0f;

    public GameObject LeftHandPos;
    public GameObject LeftHand;

    private GameObject spawnedHand;

    private Vector3 leftPos;


    // Start is called before the first frame update
    void Start()
    {
        
     leftPos = LeftHandPos.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(waitNdie());
          
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);

        }

    }
   
    // Update is called once per frame
    void Update()
    {
        HandsAttk();

       
    }

    void HandsAttk()
    {

        Quaternion desireRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desireRotation, handsFollowRate * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * handsSpeed);

     
    }


    IEnumerator waitNdie()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        spawnedHand = Instantiate(LeftHand,leftPos, Quaternion.identity);
        //LeftHand.SetActive(true);
    }
}
