using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{
    public AudioSource audioSource;

    // First frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
        Debug.Log("Empieza Musica");
    }

    /*public void LoadScene()
    {
       
        SceneManager.LoadScene(Diablon);
        Debug.Log("Cargando Scena");
    }*/

}
