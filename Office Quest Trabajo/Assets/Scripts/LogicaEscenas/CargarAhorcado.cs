using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class CargarAhorcado : MonoBehaviour
{
    private bool JugadorDentro = false;
    
     
    

    void Update()
    {
        // Si el jugador presiona la tecla "E"
        if (Input.GetKeyDown(KeyCode.E) && JugadorDentro == true)
        {
           
            
            // Cargar la nueva escena
            SceneManager.LoadScene("Ahorcado");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            JugadorDentro = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            JugadorDentro = false;
        }
    }
}
