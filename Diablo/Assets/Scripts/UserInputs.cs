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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    {
        if(UserHP == 0)
        {
            GameOver.SetActive(true);
            MainCamera.SetActive(false);

        }
    }
}
