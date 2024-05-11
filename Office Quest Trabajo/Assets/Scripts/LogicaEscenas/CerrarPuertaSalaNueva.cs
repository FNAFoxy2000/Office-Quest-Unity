using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuertaSalaNueva : MonoBehaviour
{
    public Animator PuertaAnimator;

    public GameObject[] objectsToUnload;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            PuertaAnimator.SetBool("isOpen", false);
            Debug.Log("El jugador entro en la sala nueva");
            UnloadObjects();
        }
    }

    

    public void UnloadObjects()
    {
        foreach (GameObject obj in objectsToUnload)
        {
            obj.SetActive(false);
        }
        Debug.Log("Objetos descargados.");
    }
}
