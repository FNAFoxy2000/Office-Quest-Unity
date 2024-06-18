using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class CargarPreguntas : MonoBehaviour
{
    private bool JugadorDentro = false;
    public TMP_Text pulsaE;

    void Update()
    {
        // Si el jugador presiona la tecla "E"
        if (Input.GetKeyDown(KeyCode.E) && JugadorDentro == true)
        {
            Cursor.lockState = CursorLockMode.None;
            // Cargar la nueva escena
            SceneManager.LoadScene("Preguntas");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            JugadorDentro = true;
            pulsaE.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            JugadorDentro = false;
            pulsaE.gameObject.SetActive(false);
        }
    }
}
