using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerMuñeco : MonoBehaviour
{
    private bool jugadorDentro = false;
    public GameObject muñeco;
    int muñecos = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            // Desaparecer muñeco
            muñeco.SetActive(false);
            muñecos = PlayerPrefs.GetInt("MuñecosObtenidos");
            muñecos += 1;
            PlayerPrefs.SetInt("MuñecosObtenidos", muñecos);
            Debug.Log("Muñecos: " + muñecos);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("JUGADOR DENTRO");
            jugadorDentro = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }
}
