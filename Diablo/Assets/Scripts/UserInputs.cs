using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserInputs : MonoBehaviour
{
  
    public Slider DonHP;
    public Animator AnimCotrol;
    public Animator CrashController;
    public FixedJoystick Joystick1;
    public FixedJoystick Joystick2;
    public FixedJoystick Joystick3;

    public GameObject GameOver;
    public GameObject MainCamera;
    public GameObject prefabToSpawn; // Asigna el prefab 
    public GameObject MacheteMissile; // Asigna el prefab 

    //Movement Variables
    public Rigidbody RB;
    public float moveSpeed;
    public float moveSpeedPC=10f;
    float rotationSpeed = 20f;

    private Vector2 moveInput;

    //Rot variables
    private Vector2 rotationInput;

    //AttaqueCaC collider
    public Collider CaC;


    //AttkCargado
    private Quaternion Prot;
    public GameObject pistola;
    private GameObject spawnedBullet;
    private GameObject spawnedBullet2;
    public float bulletLife = 1f;
    public float speed = 80f;
    private MeshRenderer Visible;

    //public Machete[] macheteArray;
    public bool Boomerang = true;
    public bool Machete = true;
    public bool unarmedM;

    //Pistola
    

    //Vida Barra de Vida
    int currentHealth;
    public Vida barraDeVida;
    public int maxHealth=5;


   

    // Start is called before the first frame update
    void Start()
    {
        CaC.enabled= false;
        currentHealth = maxHealth;
        barraDeVida.SetMaxHealth(maxHealth);


    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Movement();
        MovementPC();
        RotPistola();
        RotPistola2();

        if (Joystick2.Horizontal != 0|| Joystick2.Vertical != 0)
        {
            
            AttkBullets();
        }
        if (Joystick3.Horizontal != 0 || Joystick3.Vertical != 0)
        {

            AttkMachete();
        }
    }

    void Death()
    {
        if(currentHealth <= 0)
        {
            GameOver.SetActive(true);
            MainCamera.SetActive(false);

        }
    }
    void Movement()
    {
      moveInput.x = Input.GetAxis("Horizontal");
      moveInput.y = Input.GetAxis("Vertical");
        moveInput.y = Joystick1.Vertical;
        moveInput.x = Joystick1.Horizontal;
        moveInput.Normalize();
        RB.velocity = new Vector3(moveInput.x * moveSpeed, RB.velocity.y, moveInput.y * moveSpeed);


    }
    void MovementPC()
    {

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0f, zDirection);
        transform.position += moveDirection * moveSpeedPC;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balas")|| other.CompareTag("Hands"))
        {
            currentHealth -= 1;
            barraDeVida.SetHealth(currentHealth);
            //Debug.Log("-1 HP");
        }
    }

    void RotPistola()
    {

        rotationInput.y = Joystick2.Vertical;
        rotationInput.x = Joystick2.Horizontal;
        Vector3 DirRot = rotationInput;

        if (Mathf.Approximately(rotationInput.x, 0f) && Mathf.Approximately(rotationInput.y, 0f))
            return;

        float targetAngle = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


       /* rotationInput.y = Joystick2.Vertical;
         rotationInput.x = Joystick2.Horizontal;
         Vector3 DirRot = rotationInput;



         Quaternion rotacion = Quaternion.AngleAxis(DirRot.x * 5, pistola.transform.up);
         //Quaternion rotacion = Quaternion.FromToRotation(Vector3.zero, DirRot*5); 

         Prot = rotacion;


        pistola.transform.Rotate(rotacion.eulerAngles);*/

    }

    void RotPistola2()
    {

        rotationInput.y = Joystick3.Vertical;
        rotationInput.x = Joystick3.Horizontal;
        Vector3 DirRot = rotationInput;

        if (Mathf.Approximately(rotationInput.x, 0f) && Mathf.Approximately(rotationInput.y, 0f))
            return;

        float targetAngle = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
        void AttkCaC()
    {
        StartCoroutine(ColActivate()); 
    }

    void AttkBullets()
    {
        
        if (Boomerang == true )
        {
            Debug.Log("Funciona");
                spawnedBullet=Instantiate(prefabToSpawn, pistola.transform.position, Quaternion.LookRotation(pistola.transform.right*-1));
            spawnedBullet.GetComponent<BulletsDonFix>().speed = speed;
            spawnedBullet.GetComponent<BulletsDonFix>().bulletLife = bulletLife;
            //  spawnedBullet.transform.rotation = pistola.transform.rotation;
            //spawnedBullet.transform.Rotate(Prot.eulerAngles);
            //StartCoroutine(wait());


            

            Boomerang = false;
          //    unarmedM = true;
            StartCoroutine(waitBoomerang());
        }

     }

    void AttkMachete()
    {

        if (Machete == true)
        {
            Debug.Log("Funciona");
            spawnedBullet2 = Instantiate(MacheteMissile, pistola.transform.position, Quaternion.LookRotation(pistola.transform.right * -1));
            spawnedBullet2.GetComponent<BulletsDonFix>().speed = speed;
            spawnedBullet2.GetComponent<BulletsDonFix>().bulletLife = bulletLife;
            //  spawnedBullet.transform.rotation = pistola.transform.rotation;
            //spawnedBullet.transform.Rotate(Prot.eulerAngles);
            //StartCoroutine(wait());




            Machete = false;
            //    unarmedM = true;
            StartCoroutine(wait());
        }

    }

    IEnumerator waitBoomerang()
    {
        
        yield return new WaitForSeconds(0.4f);
     ///   unarmedM = false;
        Boomerang = true;
        Debug.Log("termino el tiempo");
    }


    IEnumerator ColActivate()
    {
        CaC.enabled = true;     
        yield return new WaitForSeconds(1);
        CaC.enabled = false;
    }
    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(4f);
        Machete = true;

    }


}

