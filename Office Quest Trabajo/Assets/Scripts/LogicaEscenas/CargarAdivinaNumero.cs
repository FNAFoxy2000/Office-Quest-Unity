using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CargarAdivinaNumero : MonoBehaviour
{
    
    private bool JugadorDentro = false;
   
    void Update()
    {
        // Si el jugador presiona la tecla "E" y está dentro del área
        if (Input.GetKeyDown(KeyCode.E) && JugadorDentro)
        {

            Cursor.lockState = CursorLockMode.None;
            // Cargar la nueva escena
            
            SceneManager.LoadScene("AdivinaNumero");
           
          
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
