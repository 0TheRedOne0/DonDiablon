using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInputs : MonoBehaviour
{
    public float UserHP=5;
    public Animator AnimCotrol;
    public Animator CrashController;

    
    public GameObject GameOver;
    public GameObject MainCamera;

    //Movement Variables
    public Rigidbody RB;
    public float moveSpeed;
    private Vector2 moveInput;

    //AttaqueCaC collider
    public Collider CaC;


    // Start is called before the first frame update
    void Start()
    {
        CaC.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Movement();
    }

    void Death()
    {
        if(UserHP == 0)
        {
            GameOver.SetActive(true);
            MainCamera.SetActive(false);

        }
    }
    void Movement()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        RB.velocity = new Vector3(moveInput.x * moveSpeed, RB.velocity.y, moveInput.y * moveSpeed);

    }

    void AttkCaC()
    {
      
        
            ColActivate();
        
    }

    IEnumerator ColActivate()
    {
        CaC.enabled = true;     
        yield return new WaitForSeconds(1);
        CaC.enabled = false;
    }
}
