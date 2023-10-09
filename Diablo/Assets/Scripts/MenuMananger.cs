using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    
public void LoadScene()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Cargando Menu");
    }

}

