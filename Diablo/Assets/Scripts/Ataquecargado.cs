using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataquecargado : MonoBehaviour
{
    public GameObject prefabToSpawn; // Asigna el prefab 

    private void Start()
    {
        
    }

    private void Update()
    {
        // Inicia la corutina para instanciar el prefab cada 15 segundos
        StartCoroutine(SpawnPrefabEvery15Seconds());
    }
    private IEnumerator SpawnPrefabEvery15Seconds()
    {
        while (true)
        {
            // Instancia el prefab
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            Debug.Log("Funciona");

            // Espera 15 segundos antes de la próxima instancia
            yield return new WaitForSeconds(15f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stones")
        {

            //Desaparece proyectil
        }
        else if (collision.gameObject.tag == "Diablo")
        {
            // No pasa nada
        }

        else if (collision.gameObject.tag == "Diablo")
        {
            // cooldownx
        }
    }
}
